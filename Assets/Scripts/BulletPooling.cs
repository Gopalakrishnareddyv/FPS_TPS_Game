using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooling : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField]GameObject currentBullet;
    [SerializeField] Transform firePoint;
    public static BulletPooling bulletIstance;
    public int bulletCount=50;
    Stack<GameObject> bulletPool = new Stack<GameObject>();
    private void Awake()
    {
        if (bulletIstance == null)
        {
            bulletIstance = this;
        }
    }
    public void BulletSpawn()
    {
        if (bulletPool.Count == 0)
        {
            bulletPool.Push(Instantiate(bulletPrefab));
            bulletPool.Peek().SetActive(false);
            bulletPool.Peek().name = "Bullet";
        }
        GameObject temp = bulletPool.Pop();
        temp.SetActive(true);
        bulletCount--;
        
        temp.transform.position = firePoint.position;
        temp.transform.rotation = firePoint.rotation;
        currentBullet = temp;
    }
    public void AddBullet(GameObject BulletAdd)
    {
        bulletPool.Push(BulletAdd);
        bulletPool.Peek().SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            bulletCount = 50;
        }
    }
}
