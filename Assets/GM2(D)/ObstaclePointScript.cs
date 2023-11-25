using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePointScript : MonoBehaviour
{
    public LogicScript2 logic2;
    private PointAudioScript pointAudio; // Reference to the PointAudioScript component


    // Start is called before the first frame update
    void Start()
    {
        logic2 = GameObject.FindGameObjectWithTag("Logic2").GetComponent<LogicScript2>();
        pointAudio = GameObject.FindGameObjectWithTag("PointAudio").GetComponent<PointAudioScript>(); // Assign the PointAudioScript component
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            logic2.addScore(1);

            // Play the point audio
            if (pointAudio != null)
            {
                pointAudio.PlayPointAudio();
            }
        }
    }

}