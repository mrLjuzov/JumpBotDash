using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackgroundMMTransition : MonoBehaviour
{
    private static BackgroundMMTransition instance;

    void Awake()
    {
        // Check if an instance of BackgroundMMTransition already exists
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

        // Reference to your BackgroundMM script
        BackgroundMM backgroundMM = GetComponent<BackgroundMM>();

        // Check the scene index and decide whether to enable or disable the BackgroundMM script and GameObject
        if (sceneIndex == 0 || sceneIndex == 4) // Replace with the desired scene indices
        {
            // Enable the BackgroundMM script if it's not already enabled
            if (!backgroundMM.enabled)
            {
                backgroundMM.enabled = true;
            }

            // Enable the GameObject if it's disabled
            if (!backgroundMM.gameObject.activeSelf)
            {
                backgroundMM.gameObject.SetActive(true);
            }
        }
        else
        {
            // Check the tag of the BackgroundMM GameObject and disable both the script and GameObject if the tag is "BackgroundMM"
            if (backgroundMM.gameObject.CompareTag("BackgroundMM"))
            {
                // Disable the BackgroundMM script
                backgroundMM.enabled = false;

                // Disable the GameObject
                backgroundMM.gameObject.SetActive(false);
            }
        }
    }
}


