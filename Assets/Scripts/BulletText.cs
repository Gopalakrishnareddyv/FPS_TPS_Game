using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletText : MonoBehaviour
{
    [SerializeField] Text bulletText;
    //[SerializeField] Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletText.text = "Bullets : " + BulletPooling.bulletIstance.bulletCount;
    }
}
