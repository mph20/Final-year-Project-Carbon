using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guy_Audio : MonoBehaviour
{
    public AudioClip footstep;

    public AudioClip jumpSound;

    public AudioSource source;


    void StepSound(){

        source.PlayOneShot(footstep);
    }

    void JumpSound(){

        source.PlayOneShot(jumpSound);
    }
}
