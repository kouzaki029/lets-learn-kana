using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
// class variables
    public AudioSource soundPlayer;

// class methods
    void OnMouseDown()
    {
        soundPlayer = GetComponent<AudioSource>();
        soundPlayer.Play();
    }
}
