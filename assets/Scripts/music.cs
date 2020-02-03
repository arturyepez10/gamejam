using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip audio;

    // Variable que checkea si el Jugador toca el piso
    void Start() {
        GetComponent<AudioSource>().PlayOneShot(audio, 0.5f);
    }

}