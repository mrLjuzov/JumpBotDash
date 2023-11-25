using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    private PointAudioScript pointAudio; // Reference to the PointAudioScript component

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic1").GetComponent<LogicScript>();
        pointAudio = GameObject.FindGameObjectWithTag("PointAudio").GetComponent<PointAudioScript>(); // Assign the PointAudioScript component
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logic.addScore(1);

            // Play the point audio
            if (pointAudio != null)
            {
                pointAudio.PlayPointAudio();
            }
        }
    }
}


