using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideAudioScript : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Initially, disable the audio
        audioSource.enabled = false;
    }

    // Call this function to play the audio
    public void PlayCollideAudio()
    {
        // Enable the audio source and play the audio
        if (audioSource != null)
        {
            audioSource.enabled = true;
            audioSource.Play();
        }
    }
}