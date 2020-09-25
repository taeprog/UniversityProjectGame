using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSoundController : MonoBehaviour
{
    public GroundChecker groundChecker;
    private AudioSource audio;
  
    void Start()
    {
        audio = GetComponent<AudioSource>();
        float newSpeed = 2f;
        audio.pitch = newSpeed;
        audio.outputAudioMixerGroup.audioMixer.SetFloat("Pitch", 1f / newSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") != 0.0f) && !audio.isPlaying && groundChecker.isGrounded() && Time.timeScale==1)
        {
            audio.Play();
        }
        else if(audio.isPlaying)
        {
            audio.Pause();
        }
    }
}
