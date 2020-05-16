using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Enemy : MonoBehaviour
{

    public int health = 100;
    public int damage = 50;
    public float speed = 5f;
    public bool isFlipped = false;
    public bool playerInSight = false;
    private bool dead = false;

    public Transform castPoint;
    public Transform castEnd;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D col) {

        if(col.collider.tag == "PBullet"){

            health -= damage;
        }
        
    }

    void OnTriggerEnter2D(Collider2D trig) {

        if(trig.gameObject.CompareTag("Turn")){
            flip();
        }
    }

    void deathCheck(){

        if(health <= 0){
            animator.Play("Enemy_Death");
            Destroy(gameObject,5f);
            dead = true;
        }
    }

    void Update(){

        deathCheck();
        Sight();
        if(dead)
        playerInSight = false;
        if(!dead && !playerInSight){
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        animator.Play("Enemy_Walk");
        }

        if(!dead && playerInSight){

            animator.Play("Enemy_Idle");
        }
    }

    void flip(){
        
        transform.Rotate(0f,180f,0f);
        isFlipped = !isFlipped;
    }

    void Sight(){

        Debug.DrawLine(castPoint.position, castEnd.position, Color.blue);
        playerInSight = Physics2D.Linecast(castPoint.position, castEnd.position, 1 << LayerMask.NameToLayer("Player"));
    
    }

}
