using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jaguarscript : MonoBehaviour
{
    public GameObject jaguar;
    public float mspeed=1;
    public float maxmove;
    private float max;
    private float min;
    public bool isright=true;
    public GameObject playerCharacter;
    private SpriteRenderer spriteRenderer;
    public bool pouncemode=false;
    public GameObject jaguarbody;
    private Rigidbody2D jaguarrbody;
    public float jumpXSpeed=10;
    public float jumpYSpeed=10;
    // Start is called before the first frame update
    void Start()
    {
        
        max=jaguar.transform.position.x;
        max+=maxmove;
        min=jaguar.transform.position.x;
        min-=maxmove;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate(){
       
        if(!pouncemode){
        if(jaguar.transform.position.x>=(max) && isright==true){
            //jaguar has moved far enough right
            Flip();
        }
        if(jaguar.transform.position.x<=(min) && isright==false){
            //jaguar has moved far enough left            
            Flip();
        }
        //add the mspeed*time.fixeddeltatime value to the jaguars current x position so that it moves
        jaguar.transform.position+=new Vector3(mspeed*Time.fixedDeltaTime,0,0);
        }
    }
    public void Flip () {
        //here your flip function, as example
        isright = !isright;
        Vector3 tmpScale = jaguar.transform.localScale;
        tmpScale.x *= -1;
        jaguar.transform.localScale = tmpScale;
        mspeed*=-1;
    }
    public void Pounce(){

        jaguarrbody=jaguarbody.GetComponent<Rigidbody2D>();
        //new Vector2(jumpXSpeed,jumpYSpeed)
        jaguarrbody.AddForce(jaguarbody.transform.TransformDirection(Vector3.up) *Time.fixedDeltaTime * jumpYSpeed);
        if(isright==false)
        jaguarrbody.AddForce(jaguarbody.transform.TransformDirection(Vector3.left) *Time.fixedDeltaTime * jumpXSpeed);
        else
        if(isright==true)
        jaguarrbody.AddForce(jaguarbody.transform.TransformDirection(Vector3.right) *Time.fixedDeltaTime * jumpXSpeed);
        jaguarbody.GetComponent<AudioSource>().Play();
        //jaguarbody.GetComponent<Animator>().SetBool("pounce", true);
        
    }
    public void stoppounceanim() {
        jaguarbody.GetComponent<Animator>().SetBool("pounce", false);
    }
    public void startpounceanim() {
        jaguarbody.GetComponent<Animator>().SetBool("pounce", true);
    }
    public void idlepounceanim() {
        jaguarbody.GetComponent<Animator>().SetBool("cooldown", true);
    }
    public void stopidlepounceanim() {
        jaguarbody.GetComponent<Animator>().SetBool("cooldown", false);
    }
}
