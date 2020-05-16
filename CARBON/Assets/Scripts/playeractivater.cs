using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeractivater : MonoBehaviour
{
    public GameObject guy;
    // Start is called before the first frame update
    void Start()
    {
        guy.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
