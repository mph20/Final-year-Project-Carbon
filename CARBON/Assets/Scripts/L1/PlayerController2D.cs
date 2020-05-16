using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController2D : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    bool isGrounded;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    Transform groundCheckL;

    [SerializeField]
    Transform groundCheckR;

    [SerializeField]
    GameObject player;

    [SerializeField]
    Text lifetext;

    [SerializeField]
    GameObject deadUI;



       
    public float runSpeed = 10f;
    public int lives=5;

   
    public float jumpSpeed = 15f;

    private bool isDead = false;
    private bool once=false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        AudioListener.pause=false;

        

        
    }

    // Update is called once per frame

    private void FixedUpdate() {

        if( (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))) ||
            (Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground"))) ||
            (Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground")))) {

            isGrounded = true;
        }
        else{
            isGrounded = false;
        }
        
        if(Input.GetKey("d") || Input.GetKey("right")){
            rb2d.velocity = new Vector2(runSpeed,rb2d.velocity.y);

            if(isGrounded)
            animator.Play("L1_Walk");
            spriteRenderer.flipX = false;


        }
        else if(Input.GetKey("a") || Input.GetKey("left")){
            rb2d.velocity = new Vector2(-runSpeed,rb2d.velocity.y);

            if(isGrounded)
            animator.Play("L1_Walk");
            spriteRenderer.flipX = true;

        }
        else{
            rb2d.velocity = new Vector2(0,rb2d.velocity.y);

            if(isGrounded)
            animator.Play("L1_Idle");

        }

        if((Input.GetKey("w") || Input.GetKey("up")) && isGrounded){
            rb2d.velocity = new Vector2(rb2d.velocity.x,jumpSpeed);
            animator.Play("L1_Jump");

        }
    
        if(player.transform.position.y<-2.5){
           // Debug.Log("you is ded");
            isDead = true;
            
        }
        if(isDead && !once){
            AudioListener.pause=true;            
            lifetext.text=lives.ToString();
            lives=lives-1;
            if(lives < 0)
                mainMenu();
            deadUI.gameObject.SetActive(true);
            once=true;
            Invoke("reset",2);
            
        }

        if(player.transform.position.x>305){
           // Debug.Log("you win");
            lvl1_2();
            
        }

        if(player.transform.position.y>105 && player.transform.position.x>17.5f){
         //   Debug.Log("you win");
            lvl1_3();
            
        }
    }

    void OnCollisionEnter2D(Collision2D collision){

        if (collision.gameObject.tag == "Boulder")
        {
           // Debug.Log("you is ded");
            isDead = true;
            
           

        }
    }
    void reset(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void mainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    void lvl1_2(){
        SceneManager.LoadScene("Level_1.2");
    }
    void lvl1_3(){
        SceneManager.LoadScene("Level_1.3");
    }
    void OnDisable(){
        PlayerPrefs.SetInt("playerlives",lives);
    }
    void OnEnable(){
        lives=PlayerPrefs.GetInt("playerlives");
    }
    public void SetCarry(){
        PlayerPrefs.SetInt("playerlives",5);
    }
}
