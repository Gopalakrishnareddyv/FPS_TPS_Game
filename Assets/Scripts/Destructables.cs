using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructables : MonoBehaviour
{
    [SerializeField] GameObject crateDestroyed;


    public void OncrateDestroy()
    {
        Instantiate(crateDestroyed,transform.position,transform.rotation);
        Destroy(this.gameObject);
    }
}
