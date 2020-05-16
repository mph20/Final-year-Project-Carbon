using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder_spawn : MonoBehaviour
{
    [SerializeField]
    GameObject boulder;

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
        if((player.transform.position.x > 40 && player.transform.position.x <50) && (boul_check==false)){
            //Debug.Log(boulder.name);
            boul_check=true;
            Instantiate(boulder,new Vector3(65f, 5.5f, player.transform.position.z),boulder.transform.rotation);
        }
        if((player.transform.position.x > 160 && player.transform.position.x < 170) && (boul_check2==false)){
           // Debug.Log("spawn boulder");
            boul_check2=true;
            Instantiate(boulder,new Vector3(188f, 6.5f, player.transform.position.z),boulder.transform.rotation);
        }
        
    }
  
}
