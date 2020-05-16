using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder_spawn_vertical : MonoBehaviour
{
    [SerializeField]
    GameObject boulder;

    [SerializeField]
    GameObject player;
    Vector3 position;
    bool boul_check=false;
    bool boul_check2=false;
    bool boul_check3=false;
    bool boul_check4=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if((player.transform.position.y > 7.5 && player.transform.position.y <20) && (boul_check==false)){
            //Debug.Log(boulder.name);
            boul_check=true;
            Instantiate(boulder,new Vector3(15f, 25.5f, player.transform.position.z),boulder.transform.rotation);
        }
        if((player.transform.position.y > 30 && player.transform.position.y < 40) && (boul_check2==false)){
           // Debug.Log("spawn boulder");
            boul_check2=true;
            Instantiate(boulder,new Vector3(9f, 46.5f, player.transform.position.z),boulder.transform.rotation);
        }

        if((player.transform.position.y > 87 && player.transform.position.y < 95) && (boul_check3==false)){
           // Debug.Log("spawn boulder");
            boul_check3=true;
            Instantiate(boulder,new Vector3(2f, 102f, player.transform.position.z),boulder.transform.rotation);
        }

        if((player.transform.position.y > 93 && player.transform.position.y < 99) && (boul_check4==false)){
           // Debug.Log("spawn boulder");
            boul_check4=true;
            Instantiate(boulder,new Vector3(4f, 105f, player.transform.position.z),boulder.transform.rotation);
            Instantiate(boulder,new Vector3(-1f, 102f, player.transform.position.z),boulder.transform.rotation);
        }
        
        
    }
  
}

