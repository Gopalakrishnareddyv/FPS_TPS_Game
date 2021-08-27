using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GunShop : MonoBehaviour
{
    //[SerializeField] GameObject coin;
    [SerializeField] GameObject coinImage;
    [SerializeField] GameObject weapon;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
                if (player != null)
                {
                    if (player.isCoin == true)
                    {
                        weapon.SetActive(true);
                        player.isCoin = false;
                        coinImage.SetActive(false);
                        Debug.Log("Collected gun");
                    }
                    else
                    {
                        Debug.Log("Please go and bring the coin");
                    }
                }
            }
        }
    }
}
