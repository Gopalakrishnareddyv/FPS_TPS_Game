using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity =Camera.main.transform.rotation* Vector3.forward * bulletSpeed;
        //StartCoroutine(BulletInActive());
        StartCoroutine(AddingBullet());
    }
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(AddingBullet());
    }
    IEnumerator BulletInActive()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
   IEnumerator AddingBullet()
    {
        yield return new WaitForSeconds(3);
        if (rb.gameObject.name == "Bullet")
        {
            BulletPooling.bulletIstance.AddBullet(rb.gameObject);
        }
    }
}
