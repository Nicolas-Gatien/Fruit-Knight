using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    public OVRInput.Controller controller;
    public AudioSource sliceAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VibrateController()
    {
        sliceAudio.pitch = Random.Range(0.7f, 1.5f);
        sliceAudio.Play();
       // VibrationManager.singleton.TriggerVibration(sliceAudio.clip, controller);
    }
}
