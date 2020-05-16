using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


public class audiowork : MonoBehaviour
{
    public AudioSource source;    // The AudioSource bound to the Timeline
public AudioClip silenceClip; // An AudioClip, consists of a tiny bit of silence

public PlayableDirector director;
public TimelineAsset timeline;
 
    // Start is called before the first frame update
    void Start()
    {
        source.PlayOneShot(silenceClip);
        director.Play(timeline);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
