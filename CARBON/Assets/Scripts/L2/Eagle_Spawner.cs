using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle_Spawner : MonoBehaviour
{
[SerializeField]
    GameObject eagle;

    [SerializeField]
    GameObject player;
    Vector3 position;
    bool boul_check=false;
    bool boul_check2=false;
    bool boul_check3=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if((player.transform.position.x > 110 && player.transform.position.x <120) && (boul_check==false)){
           
            boul_check=true;
            Instantiate(eagle,new Vector3(125f, 13f, player.transform.position.z),eagle.transform.rotation);
        }
        if((player.transform.position.x > 145 && player.transform.position.x < 150) && (boul_check2==false)){
           
            boul_check2=true;
            Instantiate(eagle,new Vector3(160f, 13f, player.transform.position.z),eagle.transform.rotation);
        }
        if((player.transform.position.x > 175 && player.transform.position.x < 180) && (boul_check3==false)){
           
            boul_check3=true;
            Instantiate(eagle,new Vector3(190f, 13f, player.transform.position.z),eagle.transform.rotation);
        }
        
    }

}
