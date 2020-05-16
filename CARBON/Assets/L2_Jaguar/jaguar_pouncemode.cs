using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class jaguar_pouncemode : MonoBehaviour
{
    public GameObject playerCharacter;
    public GameObject jaguar;
    public bool isGrounded=true;
    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    Transform groundCheckL;

    [SerializeField]
    Transform groundCheckR;
    float cooldown = 0f;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if( (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))) ||
            (Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground"))) ||
            (Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground")))) {

            isGrounded = true;
        }
        else{
            isGrounded = false;
        }
        if(jaguar.GetComponent<Jaguarscript>().pouncemode==true){
        
            if (playerCharacter.transform.position.x < gameObject.transform.position.x && jaguar.GetComponent<Jaguarscript>().isright==true && isGrounded)
                jaguar.GetComponent<Jaguarscript>().Flip ();
            else
            if (playerCharacter.transform.position.x > gameObject.transform.position.x && jaguar.GetComponent<Jaguarscript>().isright==false && isGrounded)
                jaguar.GetComponent<Jaguarscript>().Flip ();

            if(isGrounded && cooldown==0f){
                jaguar.GetComponent<Jaguarscript>().Pounce();
                jaguar.GetComponent<Jaguarscript>().idlepounceanim();

                if (cooldown <= 0f) cooldown = 2f;
                //isGrounded=false;
            }}
            if(cooldown > 0f){
                cooldown -= Time.deltaTime;
                if(cooldown <= 0f){
                     attack();
                }
            }
        

    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag=="Player"){
            jaguar.GetComponent<Jaguarscript>().pouncemode=true;
            jaguar.GetComponent<Jaguarscript>().startpounceanim();
        }
        

    }
     void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag=="Player"){
            jaguar.GetComponent<Jaguarscript>().pouncemode=false;
            jaguar.GetComponent<Jaguarscript>().stoppounceanim();

        }
         

    }
    void attack(){
        cooldown = 0f; // reset cooldown
        jaguar.GetComponent<Jaguarscript>().stopidlepounceanim();
    }
}
