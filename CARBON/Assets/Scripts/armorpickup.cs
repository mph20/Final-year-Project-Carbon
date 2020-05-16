using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armorpickup : MonoBehaviour
{
    public GameObject player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //add health and destroy object
        player.GetComponent<healthandarmor>().armor += 1;
        Destroy(gameObject);
    }
}
