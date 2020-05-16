using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrackWorkaround : MonoBehaviour
{
public AudioSource source;    // The AudioSource bound to the Timeline
public AudioClip silenceClip; // An AudioClip, consists of a tiny bit of silence
 
private void audioTrackWorkaround()
{
    source.PlayOneShot(silenceClip);
    // Now any Timeline can use this AudioSource
    // as a binding target and work correctly
}
}