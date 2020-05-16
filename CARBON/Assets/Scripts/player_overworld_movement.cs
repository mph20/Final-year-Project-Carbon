using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_overworld_movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject mainguy;
    bool moving = false;
    private GameObject curNode = null;
    private GameObject nextNode;
    private GameObject prevNode;
    private bool finish = false;
    public Sprite nextimg;
    public Sprite doneimg;
    Animator anim;
    GameObject objToSpawn;
    public AudioClip arcticsound;
    public AudioClip forestsound;
    public AudioClip americasound;

    node_lock checker;
    bool islocked;
    
    


    void Start()
    {
        PlayerPrefs.SetString("currnode","start");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");


        float moveVertical = Input.GetAxis("Vertical");
        if (moveHorizontal == -1 && nextNode.GetComponent<node_lock>().lock_node == false)
        {
            moving = true;
        }
        if ((mainguy.transform.position != nextNode.transform.position) && moving == true)
        {
            mainguy.transform.position = Vector3.MoveTowards(mainguy.transform.position,
                                                            nextNode.transform.position,
                                                            4f * Time.deltaTime);
        }
        else
        {
            moving = false;

        }
        if (moving == false && finish == true)
        {
            if ((mainguy.transform.position != curNode.transform.position))
            {
                mainguy.transform.position = Vector3.MoveTowards(mainguy.transform.position,
                                                                curNode.transform.position,
                                                                4f * Time.deltaTime);
            }
            else { finish = false; }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (PlayerPrefs.GetString("currnode") == "start")
            {
                //start of game no nodes unlocked yet starting at antartica
                PlayerPrefs.SetString("currnode", "anode");
                objToSpawn = new GameObject("sound producer");
                AudioSource audioSource = objToSpawn.AddComponent<AudioSource>();
                //objToSpawn.GetComponent<AudioSource>();
                audioSource.clip = arcticsound;
                audioSource.Play();
                Destroy(objToSpawn, 4);
                Invoke("lvl1_1",4);
            }
            else
            if (PlayerPrefs.GetString("currnode") == "anode")
            {
                //after completing the first level the current node will be antartica and when moving it will change to SA so we load south america as we are on that node
               // PlayerPrefs.SetString("currnode", "anode");
                Invoke("lvl1_1",4);
            }
            else
            if (PlayerPrefs.GetString("currnode") == "sanode")
            {
                //theplayer will then move to the NA node and so we load north america or level 3
                PlayerPrefs.SetString("currnode", "sanode");
                objToSpawn = new GameObject("sound producer");
                AudioSource audioSource = objToSpawn.AddComponent<AudioSource>();
                //objToSpawn.GetComponent<AudioSource>();
                audioSource.clip = forestsound;
                audioSource.Play();
                Destroy(objToSpawn, 4);
                Invoke("lvl2",4);
            }
            else
            if (PlayerPrefs.GetString("currnode") == "nanode")
            {
                //player has beaten level 3 and moved on the map to africa 
                PlayerPrefs.SetString("currnode", "nanode");
                objToSpawn = new GameObject("sound producer");
                AudioSource audioSource = objToSpawn.AddComponent<AudioSource>();
                //objToSpawn.GetComponent<AudioSource>();
                audioSource.clip = americasound;
                audioSource.Play();
                Destroy(objToSpawn, 4);
                Invoke("lvl3",4);
            }
        }
            
        if (Input.GetKeyDown(KeyCode.Space))
        {
            nextNode.GetComponent<node_lock>().lock_node = false;
            curNode.GetComponent<SpriteRenderer>().sprite = doneimg;
            anim = curNode.GetComponent<Animator>();
            if (anim)
            {
                anim.SetBool("isNext", false);
                curNode.GetComponent<SpriteRenderer>().sprite = doneimg;
            }
            anim = nextNode.GetComponent<Animator>();
            anim.SetBool("isNext", true);
        }



    }
    private void OnCollisionEnter2D(Collision2D node)
    {
        if (node.gameObject.CompareTag("anode") || node.gameObject.CompareTag("sanode")
        || node.gameObject.CompareTag("nanode") || node.gameObject.CompareTag("eunode")
        || node.gameObject.CompareTag("ausnode") || node.gameObject.CompareTag("asianode")
        || node.gameObject.CompareTag("afnode"))
        {
            curNode = node.gameObject;
            
            moving = false;
            finish = true;
            nextNode = curNode.GetComponent<node_lock>().nextlocation;
            prevNode = curNode.GetComponent<node_lock>().prevlocation;
            Debug.Log("Do something else here");
            Debug.Log(curNode.name);
        }

    }
    private void OnCollisionExit2D(Collision2D node)
    {
        if (node.gameObject.CompareTag("anode") || node.gameObject.CompareTag("sanode")
        || node.gameObject.CompareTag("nanode") || node.gameObject.CompareTag("eunode")
        || node.gameObject.CompareTag("ausnode") || node.gameObject.CompareTag("asianode")
        || node.gameObject.CompareTag("afnode"))
        {
            finish = true;
            PlayerPrefs.SetString("currnode", nextNode.tag);

        }
    }
    void OnEnable()
    {
        if (PlayerPrefs.GetString("currnode") == "start")
        {
            mainguy.transform.position = GameObject.FindWithTag("anode").transform.position;
            mainguy.GetComponent<Animator>().SetBool("ukitrue", true);
            anim = GameObject.FindWithTag("anode").GetComponent<Animator>();
            anim.SetBool("isNext", true);

        }
        else
            if (PlayerPrefs.GetString("currnode") == "anode")
            {
                mainguy.transform.position = GameObject.FindWithTag("anode").transform.position;
                mainguy.GetComponent<Animator>().SetBool("hombretrue", true);
                nextNode = GameObject.FindWithTag("anode").GetComponent<node_lock>().nextlocation;
                nextNode.GetComponent<node_lock>().lock_node = false;
                anim = nextNode.GetComponent<Animator>();
                anim.SetBool("isNext", true);
                curNode = GameObject.FindWithTag("anode");
                anim = curNode.GetComponent<Animator>();
                anim.SetBool("skip", true);

        }
        else
            if (PlayerPrefs.GetString("currnode") == "sanode")
            {
            mainguy.transform.position = GameObject.FindWithTag("sanode").transform.position;
            mainguy.GetComponent<Animator>().SetBool("adamtrue", true);
            nextNode =GameObject.FindWithTag("sanode").GetComponent<node_lock>().nextlocation;
            nextNode.GetComponent<node_lock>().lock_node = false;
            anim = nextNode.GetComponent<Animator>();
            anim.SetBool("isNext", true);
            curNode=GameObject.FindWithTag("sanode");
            anim = curNode.GetComponent<Animator>();
            anim.SetBool("skip", true);
            curNode.GetComponent<SpriteRenderer>().sprite = doneimg;
            prevNode = GameObject.FindWithTag("sanode").GetComponent<node_lock>().prevlocation;
            anim = prevNode.GetComponent<Animator>();
            anim.SetBool("skip", true);
            prevNode.GetComponent<SpriteRenderer>().sprite = doneimg;
            }
        else
            if (PlayerPrefs.GetString("currnode") == "nanode") {
                mainguy.transform.position = GameObject.FindWithTag("nanode").transform.position;
            mainguy.GetComponent<Animator>().SetBool("adamtrue", true);
                nextNode = GameObject.FindWithTag("nanode").GetComponent<node_lock>().nextlocation;
                nextNode.GetComponent<node_lock>().lock_node = false;
                anim = nextNode.GetComponent<Animator>();
                anim.SetBool("isNext", true);

                curNode = GameObject.FindWithTag("nanode");
                anim = curNode.GetComponent<Animator>();
                anim.SetBool("skip", true);

                prevNode = GameObject.FindWithTag("sanode").GetComponent<node_lock>().prevlocation;
                anim = prevNode.GetComponent<Animator>();
                anim.SetBool("skip", true);

                prevNode = GameObject.FindWithTag("nanode").GetComponent<node_lock>().prevlocation;
                anim = prevNode.GetComponent<Animator>();
                anim.SetBool("skip", true);
        }
    }
    void lvl1_1(){
        SceneManager.LoadScene("Level_1.1");
    }
    void lvl2(){
        SceneManager.LoadScene("Level_2");
    }
    void lvl3(){
        SceneManager.LoadScene("Level_3");
    }
}
