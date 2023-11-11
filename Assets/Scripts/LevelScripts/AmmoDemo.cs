using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDemo : MonoBehaviour
{
    public RectTransform imageRectTransform;

    void Start()
    {
        if (imageRectTransform == null)
        {
            imageRectTransform = GetComponent<RectTransform>();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Check for left mouse button click
        {
            // Rotate the image by 60 degrees on the Z-axis
            imageRectTransform.Rotate(new Vector3(0, 0, 60));
        }
    }
}

