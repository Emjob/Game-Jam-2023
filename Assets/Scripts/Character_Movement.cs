using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    Rigidbody rb;

    public float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    public float dashDuration;
    public float dashSpeed;
    private bool isDashing;

    private Vector3 input;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(isDashing)
        {
            return;
        }

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        input = new Vector3(horizontalInput, 0, verticalInput).normalized;

        rb.velocity = new Vector3(input.x * playerSpeed, 0, input.z * playerSpeed);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Dash());
        }

    }
    
    private IEnumerator Dash()
    {
        isDashing = true;
        rb.velocity = new Vector3(input.x * dashSpeed, 0, input.z * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }
}
