using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript : MonoBehaviour

{
    public Rigidbody2D myRigidBody;
    public float jumpStrength;
    public LogicScript logic;
    private bool robotIsAlive = true;

    // Reference to the CollideAudioScript component
    private CollideAudioScript collideAudio;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic1").GetComponent<LogicScript>();
        collideAudio = GameObject.FindGameObjectWithTag("CollideAudio").GetComponent<CollideAudioScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && robotIsAlive)
        {
            myRigidBody.velocity = Vector2.up * jumpStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Play collision audio
        if (collideAudio != null)
        {
            collideAudio.PlayCollideAudio();
        }

        logic.gameOver();
        robotIsAlive = false;

        Destroy(gameObject);
        Debug.Log("Robot Deleted");
    }

    // This method is called when the object becomes invisible
    private void OnBecameInvisible()
    {
        if (robotIsAlive)
        {
            // Play collision audio
            if (collideAudio != null)
            {
                collideAudio.PlayCollideAudio();
            }

            // Call the game over function when the character leaves the screen
            logic.gameOver();
            robotIsAlive = false;

            Destroy(gameObject);
            Debug.Log("Robot Deleted");
        }
    }
}

