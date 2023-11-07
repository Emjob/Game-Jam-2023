using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    public float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    private void Start()
    {
        
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 input = new Vector3 (horizontalInput, 0, verticalInput);
        transform.Translate(input * Time.deltaTime * playerSpeed);

    }
    
}
