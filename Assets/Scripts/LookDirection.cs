using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookDirection : MonoBehaviour
{
    [SerializeField] float rotateYSpeed=2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * rotateYSpeed * Time.deltaTime, 0);
        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, (transform.localEulerAngles.y + mouseX)* rotateYSpeed, transform.localEulerAngles.z);
    }
}
