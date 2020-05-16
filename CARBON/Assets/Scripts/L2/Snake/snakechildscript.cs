using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakechildscript : MonoBehaviour
{
    public GameObject snake;
    public GameObject playerCharacter;
    public bool facingRight = false;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator=gameObject.GetComponentInParent(typeof(Animator)) as Animator;
        spriteRenderer = GetComponentInParent(typeof(SpriteRenderer)) as SpriteRenderer;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerCharacter.transform.position.x < gameObject.transform.position.x && facingRight)
            Flip ();
        if (playerCharacter.transform.position.x > gameObject.transform.position.x && !facingRight)
            Flip ();
    }
      void OnTriggerEnter2D(Collider2D col){
        
        if(col.gameObject.tag == "Player"){
        animator.SetBool("player_near",true);
        }

    }
     void OnTriggerExit2D(Collider2D col){

         if(col.gameObject.tag == "Player"){
         animator.SetBool("player_near",false);
         }

    }
    void Flip () {
        //here your flip function, as example
        facingRight = !facingRight;
        Vector3 tmpScale = snake.transform.localScale;
        tmpScale.x *= -1;
        snake.transform.localScale = tmpScale;
        }
}
