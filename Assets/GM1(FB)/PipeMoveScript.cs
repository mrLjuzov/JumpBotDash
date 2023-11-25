using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5f;
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
            // Check if the GameObject has the "Pipe1" tag before destroying it.
            if (gameObject.CompareTag("Pipe1"))
            {
                Debug.Log("Pipe Deleted");
                Destroy(gameObject);
            }
        }
    }
}