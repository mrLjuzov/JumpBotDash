using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundMM : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float scrollSpeed = 0.5f;
    private float offsetX;
    private float offsetY;
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offsetX += (Time.deltaTime * scrollSpeed) / 10f; // Update offsetX
        offsetY += (Time.deltaTime * scrollSpeed) / 10f; // Update offsetY

        // Make sure that both offsetX and offsetY stay within the [0, 1] range
        offsetX %= 1.0f;
        offsetY %= 1.0f;

        mat.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));
    }
}
