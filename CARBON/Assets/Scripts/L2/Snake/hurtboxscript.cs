using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtboxscript : MonoBehaviour
{
    public GameObject player;


     void OnTriggerEnter2D(Collider2D col){
        
        if(col.gameObject.tag == "Player"){
        
            player.GetComponent<Move2D>().isDead = true;
        }
    }
}
