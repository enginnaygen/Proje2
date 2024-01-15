using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        PlayerController player = collision.GetComponent<PlayerController>();
        
        if(player != null)
        {
            GameManager.Instance.LoadScene(1);
            //GameManager.Instance.LoadScene(0);
        }
    }
}
