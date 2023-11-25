using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    public float scrollX = 1.5f;
    private float scrollY = 0f;

    private void Update()
    {
        float OffsetX = Time.time * scrollX /10f;
        float OffsetY = Time.time * scrollY /10f;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);
    }
}
