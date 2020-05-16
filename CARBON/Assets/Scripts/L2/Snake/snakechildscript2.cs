using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakechildscript2 : MonoBehaviour
{
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator=gameObject.GetComponentInParent(typeof(Animator)) as Animator;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      void OnTriggerEnter2D(Collider2D col){
          if(col.gameObject.tag == "Player"){
        animator.SetBool("player_in_range",true);
          }

    }
     void OnTriggerExit2D(Collider2D col){
         if(col.gameObject.tag == "Player"){
         animator.SetBool("player_in_range",false);
         }


    }
}
