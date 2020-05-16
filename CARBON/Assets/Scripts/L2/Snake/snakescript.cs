using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakescript : MonoBehaviour
{
    public Animator animator;
    public GameObject startle;
    public GameObject in_range;
    //public GameObject startle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /*void OnTriggerEnter2D(Collider2D col){  
        Debug.Log("yes");
        Debug.Log(col.name); 
        if (col.name=="startle"){
            Debug.Log("yes");
         // set snake animation to startle animation
         animator.SetBool("player_near",true);
        }
        if (col.name=="attackrange"){
            Debug.Log("yes");
         // set snake animation to attack animation
         animator.SetBool("player_in_range",true);
        }
    }
    void OnTriggerExit2D(Collider2D col){   
        if (col.name=="startle"){
         // set snake animation to startle animation
         Debug.Log("yes");
         animator.SetBool("player_near",false);
        }
        if (col.name=="attackrange"){
         // set snake animation to attack animation
         animator.SetBool("player_in_range",false);
        }
    }
    public void OnChildTriggerEntered(Collider other, Vector3 childPosition) {
    //Do stuff
}*/
}
