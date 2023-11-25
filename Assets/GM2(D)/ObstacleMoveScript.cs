using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public float moveSpeed = 4.2f;
    public float deadZone = -14f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            // Check if the GameObject has any of the specified tags.
            if (gameObject.CompareTag("Spike1") || gameObject.CompareTag("Spike2") || gameObject.CompareTag("Rocket1") || gameObject.CompareTag("Rocket2"))
            {
                Debug.Log("Obstacle" + gameObject.name + "Deleted: ");
                Destroy(gameObject);
            }
        }
    }

}
