using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    void Awake()
    {
        // Check if an instance of AudioManager already exists
        if (instance == null)
        {
            // If not, set this as the instance and make it persistent across scenes
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // If an instance already exists, destroy this one
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        // Subscribe to the scene loading event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        // Unsubscribe from the scene loading event to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int sceneIndex = scene.buildIndex;

        // Reference to your AudioSource component
        AudioSource audioSource = GetComponent<AudioSource>();

        // Check the scene index and decide whether to play or stop the audio
        if (sceneIndex == 0 || sceneIndex == 1 || sceneIndex == 4) // Replace desiredSceneIndex with the index of the scene where audio should play
        {
            // Play audio if not already playing
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            // Stop the audio playback
            audioSource.Stop();
        }
    }

}