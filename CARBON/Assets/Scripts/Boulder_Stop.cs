using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder_Stop : MonoBehaviour
{
    
    public GameObject boulder;

    void Start()
    {
        boulder.SetActive(false);    
    }

}
