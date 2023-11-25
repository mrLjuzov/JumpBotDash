using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript2 : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float jumpStrength;
    public LogicScript2 logic2;
    private bool robotIsAlive2 = true;

    // Reference to the CollideAudioScript component
    private CollideAudioScript collideAudio;
    // Start is called before the first frame update
    void Start()
    {
        logic2 = GameObject.FindGameObjectWithTag("Logic2").GetComponent<LogicScript2>();
        collideAudio = GameObject.FindGameObjectWithTag("CollideAudio").GetComponent<CollideAudioScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && robotIsAlive2) 
        {
            myRigidBody.velocity = Vector2.up * jumpStrength;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the tag "Ground2"
        if (collision.gameObject.CompareTag("Ground2"))
        {
            // Do nothing or add any specific handling for "Ground2" collisions.
            // You can leave this block empty if you want to ignore collisions with "Ground2."
        }
        else
        {
            // Handle collisions with objects other than "Ground2"
            logic2.gameOver2();
            robotIsAlive2 = false;
            // Trigger the audio when a point is scored
            collideAudio.PlayCollideAudio();
            Destroy(gameObject);
            Debug.Log("Robot Deleted");
        }
    }

    //This method is called when the object becomes invisible
    private void OnBecameInvisible()
    {
        if (robotIsAlive2)
        {
             //Call the game over function when the character leaves the screen
            logic2.gameOver2();
            robotIsAlive2 = false;
            // Trigger the audio when a point is scored
            collideAudio.PlayCollideAudio();
            Destroy(gameObject);
            Debug.Log("Robot Deleted");
        }
    }

}
