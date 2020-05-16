using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Play_At_End : MonoBehaviour
{
     public PlayableDirector timeline;
 
    // Use this for initialization
 
    void OnTriggerEnter2D(Collider2D col){
        
        if(col.gameObject.tag == "Player"){
            timeline.Play();
        }
    }
}
