using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Crayon : MonoBehaviour
{
    NavMeshAgent enemy;
    GameObject player;
    public float moveSpeed;
    public float accel;
    private bool isDashHandler;
    private bool canDash;
    private bool isDashing;
    public float DashDuration;
    Player_Health health;
    public int Damage;



    [SerializeField] private float awayDistance;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        canDash = true;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= awayDistance && canDash)
        {
           AttackDash();
            enemy.speed = moveSpeed * 2;
            enemy.acceleration = accel * 2;
        }
        else 
        {
            Move();
            enemy.speed = moveSpeed;
            enemy.acceleration = accel;
        }

    }
    void Move()
    {
        enemy.SetDestination(player.transform.position);
    }

    void AttackDash()
    {
        if (!isDashHandler)
        {
            StartCoroutine(DashMovementHandler());

        }
        if (isDashing)
        {
            
            enemy.SetDestination(enemy.transform.position);
            
        }

             
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<Player_Health>().takeDamage(Damage);
        }
        
        
    }
    IEnumerator DashMovementHandler()
    {
        isDashHandler = true;
        canDash = true;
        yield return new WaitForSeconds(1f);
        isDashing = true;
        yield return new WaitForSeconds(0.5f);
        canDash = false;
        isDashing = false;
        yield return new WaitForSeconds(DashDuration);
        canDash = true;
        isDashHandler = false;
    }
}
