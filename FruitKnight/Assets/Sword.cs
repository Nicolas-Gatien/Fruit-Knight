using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public AudioSource sliceAudio;

    public void PlaySliceSound()
    {
        sliceAudio.pitch = Random.Range(0.7f, 1.5f); // randomize pitch
        sliceAudio.Play(); // play sound
    }
}
