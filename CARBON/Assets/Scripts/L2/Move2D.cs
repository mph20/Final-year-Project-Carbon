using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Move2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float slideSpeed = 5f;
    public int lives=5;
    public bool isGrounded = false;
    public bool isDead = false;
    public bool isSliding = false;
    private bool once=false;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    Transform groundCheckL;

    [SerializeField]
    Transform groundCheckR;


    Animator animator;
    SpriteRenderer spriteRenderer;
    
    [SerializeField]
    GameObject player;

    [SerializeField]
    Text lifetext;

    [SerializeField]
    GameObject deadUI;

    public CapsuleCollider2D regularColl;
    public BoxCollider2D slideColl;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        AudioListener.pause=false;
        
    }

    // Update is called once per frame
    void Update()
    {
       
       isPlayerDead();

       if(player.transform.position.x>356){
            lvl1_2();
            
        }

       
        
    }

    void Jump(){

        if(Input.GetButtonDown("Jump") && isGrounded == true && isSliding == false){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

    }

    void Slide(){

         if(Input.GetKey("z") && (isGrounded == true) && (isSliding == false)){

            isSliding = true;
            regularColl.enabled = false;
            slideColl.enabled = true;

            if(spriteRenderer.flipX){

                gameObject.GetComponent<Rigidbody2D>().AddForce (Vector2.left * slideSpeed);
            }
            else{

                gameObject.GetComponent<Rigidbody2D>().AddForce (Vector2.right * slideSpeed);
            }

            Invoke("stopSlide",0.5f);

        }


    }

    void stopSlide(){
        isSliding = false;
        regularColl.enabled = true;
        slideColl.enabled = false; 
    }

    void isPlayerDead(){

        if(player.transform.position.y<-0.5 && player.transform.position.x < 277){
            isDead = true;    
        }
        if(player.transform.position.y<-23 && player.transform.position.x > 277){
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


    }

    private void FixedUpdate() {


        if( (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))) ||
            (Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground"))) ||
            (Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground")))) {

            isGrounded = true;
        }
        else{
            isGrounded = false;
        }

        Jump();
        Slide();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        
        if(isSliding){

                animator.Play("L2_Dash");
        }
        else if(Input.GetKey("d") || Input.GetKey("right")){
            if(isGrounded)
                animator.Play("L2_Walk");
            spriteRenderer.flipX = false;
        }
        else if(Input.GetKey("a") || Input.GetKey("left")){

            if(isGrounded)
                animator.Play("L2_Walk");
            spriteRenderer.flipX = true;
        } 
        else{
            if(isGrounded)
            animator.Play("L2_Idle");
        }
        
        if(!isGrounded && !isSliding){
            animator.Play("L2_Jump");
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
    public void SetDead(){
        isDead = true;
    }
    
}
