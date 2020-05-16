using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder_spawn_3 : MonoBehaviour
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
    bool boul_check5=false;
    bool boul_check6=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if((player.transform.position.x > 40 && player.transform.position.x <50) && (boul_check==false)){
            //Debug.Log(boulder.name);
            boul_check=true;
            Instantiate(boulder,new Vector3(65f, 5.5f, player.transform.position.z),boulder.transform.rotation);
        }
        if((player.transform.position.x > 130 && player.transform.position.x < 140) && (boul_check2==false)){
           // Debug.Log("spawn boulder");
            boul_check2=true;
            Instantiate(boulder,new Vector3(146f, 9.5f, player.transform.position.z),boulder.transform.rotation);
        }
        if((player.transform.position.x > 146 && player.transform.position.x < 150) && (boul_check3==false)){
           // Debug.Log("spawn boulder");
            boul_check3=true;
            Instantiate(boulder,new Vector3(164f, 10f, player.transform.position.z),boulder.transform.rotation);
        }
        if((player.transform.position.x > 300 && player.transform.position.x < 310) && (boul_check4==false)){
           // Debug.Log("spawn boulder");
            boul_check4=true;
            Instantiate(boulder,new Vector3(320f, 10f, player.transform.position.z),boulder.transform.rotation);
        }
        if((player.transform.position.x > 330 && player.transform.position.x < 340) && (boul_check5==false)){
           // Debug.Log("spawn boulder");
            boul_check5=true;
            Instantiate(boulder,new Vector3(349f, 10f, player.transform.position.z),boulder.transform.rotation);
        }
        if((player.transform.position.x > 356 && player.transform.position.x < 360) && (boul_check6==false)){
           // Debug.Log("spawn boulder");
            boul_check6=true;
            Instantiate(boulder,new Vector3(381f, 10f, player.transform.position.z),boulder.transform.rotation);
        }
    }
  
}
