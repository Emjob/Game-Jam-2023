using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_Movement : MonoBehaviour
{
    Rigidbody rb;

    public float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    [SerializeField] private Image dashImage;

    [SerializeField]private GameObject[] Enemies;

    public float dashDuration;
    public float dashSpeed;
    private bool isDashing;

    public bool healOnKill;
    public bool bulletShield;
    public bool canDash;
    public bool doubleShot;
    public bool canKnock;
    public bool canHome;
    public bool homing;

    private Vector3 input;

    [SerializeField]  Gun Bullet;

    private void Start()
    {
        updateAbilities();
        canDash = true;
        rb = GetComponent<Rigidbody>();
     //   Bullet = GetComponent<Gun>();
    }

    void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        


        if(canDash == false )
        {
            dashImage.enabled = false;
        }

        if (isDashing)
        {
            dashImage.enabled = false;
            return;
        }
        else
        {
            dashImage.enabled =true;
        }
        

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        input = new Vector3(horizontalInput, 0, verticalInput).normalized;

        rb.velocity = new Vector3(input.x * playerSpeed, 0, input.z * playerSpeed);
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
        if(Input.GetKeyDown(KeyCode.R) && canKnock)
        {
            for(int i = 0; i < Enemies.Length; i++)
            {
                Enemies[i].GetComponent<Enemy_Health>().KnockBack();
                Debug.Log("Key Register");
            }
        }
        if(canHome && Input.GetKeyDown(KeyCode.F))
        {
            homing = true;
        }
     //   Debug.Log(rb.velocity);
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        rb.velocity = new Vector3(input.x * dashSpeed, 0, input.z * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }

    public void updateAbilities()
    {
        if (Bullet.BulletNames.Contains("Purple Bullet"))
        {
            canDash = true;
        }
        else
        {
            canDash = false;
        }
        if (Bullet.BulletNames.Contains("Green Bullet"))
        {
            healOnKill = true;
        }
        else
        {
            healOnKill = false;
        }
        if (Bullet.BulletNames.Contains("Blue Bullet"))
        {
            bulletShield = true;
        }
        else
        {
            bulletShield = false;
        }
        if (Bullet.BulletNames.Contains("Yellow Bullet"))
        {
            doubleShot = true;
        }
        else
        {
            doubleShot = false;
        }
        if (Bullet.BulletNames.Contains("Orange Bullet"))
        {
            canKnock = true;
        }
        else
        {
            canKnock = false;
        }
        if (Bullet.BulletNames.Contains("Red Bullet"))
        {
            canHome = true;
        }
        else
        {
            canHome = false;
        }
    }
}
