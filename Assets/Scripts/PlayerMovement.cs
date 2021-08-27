using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController character;
    [SerializeField] float playerSpeed;
    float gravity = 9.8f;
    [SerializeField] ParticleSystem muzzleFlashPrefab;
    [SerializeField] GameObject hitMarkerPrefab;
    AudioSource audioSource;
    [SerializeField] AudioClip shootAudio;
    [SerializeField] Transform firePosition;
    [SerializeField]float fireRate = 1f;
    public bool isCoin = false;
    [SerializeField] AudioClip coinClip;
    [SerializeField] GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (weapon.activeInHierarchy)
        {
            FireGun();
        }
    }
    public void Movement()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 velocity = direction * playerSpeed;
        velocity.y -= gravity;
        character.Move(velocity * Time.deltaTime);
    }
    public void FireGun()
    {
        fireRate -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && fireRate <= 0)
        {
            
            if (BulletPooling.bulletIstance.bulletCount >0)
            {
                BulletPooling.bulletIstance.BulletSpawn();
                fireRate = 1f;
                
                
            }
            
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2f,Screen.height/2f,0f));
            RaycastHit hit;
            //Debug.Log(Physics.Raycast(ray,out hit, Mathf.Infinity));
            if (Physics.Raycast(ray, out hit,Mathf.Infinity))
            {
                //Debug.Log("Raycast hit");
                //GameObject temp=Instantiate(hitMarkerPrefab, hit.point, Quaternion.identity);
                //Destroy(temp, 1f);
                GameObject effect = Pooling.instance.GetPoolObject("HitMarker");
                if (effect != null&&hit.collider.gameObject.tag!="Bullet")
                {
                    effect.transform.position = hit.point;
                    effect.SetActive(true);
                    StartCoroutine(HitMarkerInActive(effect));
                    audioSource.clip = shootAudio;
                    audioSource.Play();
                }
                Destructables crate = hit.transform.GetComponent<Destructables>();
                if (crate != null)
                {
                    crate.OncrateDestroy();
                }
            }
            else
            {
                
                muzzleFlashPrefab.Play();
                StartCoroutine(ParticleStop());
                audioSource.clip = shootAudio;
                audioSource.Play();
            }
            if (isCoin)
            {
                audioSource.clip = coinClip;
                audioSource.Play();
            }
        }
    }
    IEnumerator ParticleStop()
    {
        yield return new WaitForSeconds(1);
        muzzleFlashPrefab.Stop();
    }
    IEnumerator HitMarkerInActive(GameObject effect)
    {
        yield return new WaitForSeconds(1);
        effect.SetActive(false);
    }
}
