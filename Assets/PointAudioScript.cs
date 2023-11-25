using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PointAudioScript : MonoBehaviour
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
    public void PlayPointAudio()
    {
        // Enable the audio source and play the audio
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.enabled = true;
            audioSource.Play();
        }
    }
}

