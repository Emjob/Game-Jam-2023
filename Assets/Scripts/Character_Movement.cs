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
    private bool canDash;

    private Vector3 input;

    Gun Bullet;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Bullet = GetComponent<Gun>();
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
            abilityAction();
            //StartCoroutine(Dash());
        }

    }
    
    private IEnumerator Dash()
    {
        isDashing = true;
        rb.velocity = new Vector3(input.x * dashSpeed, 0, input.z * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }

    private void abilityAction()
    {
        switch(Bullet.Loaded)
        {
            case "Red Bullet":
                Debug.Log("1");
                break;
            case "Blue Bullet":
                Debug.Log("2");
                break;
            case "Green Bullet":
                Debug.Log("3");
                break;
            case "Brown Bullet":
                Debug.Log("4");
                break;
            case "Purple Bullet":
                StartCoroutine(Dash());
                Debug.Log("5");
                break;
            case "Yellow Bullet":
                Debug.Log("6");
                break;
        }
    }
}
