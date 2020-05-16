using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log_Spawner : MonoBehaviour
{
[SerializeField]
    GameObject log;

    [SerializeField]
    GameObject player;
    Vector3 position;
    bool boul_check=false;
    bool boul_check2=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if((player.transform.position.x > 98 && player.transform.position.x <100) && (boul_check==false)){
            //Debug.Log(log.name);
            boul_check=true;
            Instantiate(log,new Vector3(99f, 0f, player.transform.position.z),log.transform.rotation);
        }
        if((player.transform.position.x > 240 && player.transform.position.x < 245) && (boul_check2==false)){
           // Debug.Log("spawn log");
            boul_check2=true;
            Instantiate(log,new Vector3(242f, 0f, player.transform.position.z),log.transform.rotation);
        }
        
    }

}
