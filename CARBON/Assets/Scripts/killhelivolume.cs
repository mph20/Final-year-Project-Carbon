using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class killhelivolume : MonoBehaviour
{
     public AudioSource m_MyAudioSource;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        m_MyAudioSource.volume -=(0.5f*Time.deltaTime);
        
    }
}
