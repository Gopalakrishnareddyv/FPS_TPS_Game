using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooling : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField]GameObject currentBullet;
    [SerializeField] Transform firePoint;
    public static BulletPooling bulletIstance;
    public int bulletCount;
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
            bulletCount++;
            bulletPool.Peek().SetActive(false);
            bulletPool.Peek().name = "Bullet";
        }
        GameObject temp = bulletPool.Pop();
        temp.SetActive(true);
        temp.transform.position = firePoint.position;
        temp.transform.rotation = firePoint.rotation;
        currentBullet = temp;
    }
    public void AddBullet(GameObject BulletAdd)
    {
        bulletPool.Push(BulletAdd);
        bulletPool.Peek().SetActive(false);
    }
}
