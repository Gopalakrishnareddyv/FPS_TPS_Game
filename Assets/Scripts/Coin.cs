using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    
    [SerializeField] GameObject coinImage;
    private void Start()
    {
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                PlayerMovement player = other.GetComponent<PlayerMovement>();
                if (player != null)
                {
                    player.isCoin = true;
                    if (player.isCoin)
                    {
                        Debug.Log("Collected Coin");
                        this.gameObject.SetActive(false);
                        coinImage.SetActive(true);
                    }
                }
                
            }
        }
    }
}
