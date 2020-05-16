using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_Lock_Y : MonoBehaviour
{

    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;
    public float ypos = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate() {
        float temp = (cam.transform.position.x * (1- parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, ypos, transform.position.z);

        if ( temp > startpos + length) startpos += length;
        else if ( temp < startpos - length) startpos -= length;
    }
}
