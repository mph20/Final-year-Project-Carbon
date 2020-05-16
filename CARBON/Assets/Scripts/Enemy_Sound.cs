using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sound : MonoBehaviour
{
    public AudioClip deathSound;

    AudioSource source;

    void Start(){

        source = GetComponent<AudioSource>();
    }

    void DeathNoise(){

        source.PlayOneShot(deathSound);
    }
}
