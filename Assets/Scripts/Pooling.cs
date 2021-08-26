using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    public static Pooling instance;
    [SerializeField] GameObject hitmarkerPrefab;
    [SerializeField] int number;
    public List<GameObject> pooledItems= new List<GameObject>();
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < number; i++)
        {
            GameObject temp = Instantiate(hitmarkerPrefab);
            temp.SetActive(false);
            pooledItems.Add(temp);
        }
    }
    public GameObject GetPoolObject(string tagName)
    {
        for (int i = 0; i < pooledItems.Count; i++)
        {
            if (!pooledItems[i].activeInHierarchy&&pooledItems[i].tag==tagName)
            {
                return pooledItems[i];
            }
        }
        return null;
    }
}
