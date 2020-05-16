using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class eaglescript : MonoBehaviour
{
    public float speed=1;
    public GameObject eagle;
    public double initx;
    public double curx;
    public double graphx;
    public double y;
    public double offset=0;
    private float temp;
    // Start is called before the first frame update
    void Start()
    {
        initx=eagle.transform.position.x;
        y=eagle.transform.position.y;
        graphx=8;
        curx=eagle.transform.position.x;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {   

        curx-=speed*Time.fixedDeltaTime;
        graphx=graphx-(initx-curx);
        y=(graphx/2)*(graphx/2)+offset;
       
        eagle.transform.position=new Vector3((float)curx,(float)y,eagle.transform.position.z);
        initx=curx;

        if(graphx<=0){
            if(eagle.transform.rotation.z>-30){
                temp=eagle.transform.rotation.z-(1*Time.fixedDeltaTime);
                eagle.transform.rotation=Quaternion.Euler(0, 0, temp);
            }
        }
    }
}
