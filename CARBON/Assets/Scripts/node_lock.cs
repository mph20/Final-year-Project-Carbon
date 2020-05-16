using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class node_lock : MonoBehaviour
{
    private bool locked = true;
    public bool lock_node
    {
        get { return locked; }
        set { locked = value; }
    }
    [SerializeField]
    public GameObject nextlocation;
    [SerializeField]
    public GameObject prevlocation;
    void Start()
    {

    }

    void Update()
    {

    }

}
