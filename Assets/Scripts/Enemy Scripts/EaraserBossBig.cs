using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EaraserBossBig : MonoBehaviour
{
    NavMeshAgent enemy;
    GameObject player;
    [SerializeField] private float awayDistance;
    public float moveSpeed;
    public float accel;
    private bool isDashHandler;
    private bool canFlop;
    private bool isDashing;
    public float DashDuration;
    public GameObject Earaser;
    public GameObject SpawnPlace, SpawnPlace2;
    private bool spawenedFuckers;
    public int Damage;
    public Gun gun;
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        canFlop = true;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= awayDistance && canFlop)
        {
            FlopAttack();
            enemy.speed = moveSpeed * 2;
            enemy.acceleration = accel * 2;
        }
        else
        {
            Move();
            enemy.speed = moveSpeed;
            enemy.acceleration = accel;
        }
        if (GetComponent<Enemy_Health>().health <= 0)
        {
            gun.RemoveBullet();
        }
    }
    void Move()
    {
        enemy.SetDestination(player.transform.position);
    }
    
    void FlopAttack()
    {
        if (!isDashHandler)
        {
            StartCoroutine(FlopAttackHandle());

        }
        if (isDashing)
        {

            enemy.SetDestination(enemy.transform.position);
            if (enemy.remainingDistance < 0.1 && !spawenedFuckers)
            {
                Instantiate(Earaser, SpawnPlace.transform.position, SpawnPlace.transform.rotation);
                Instantiate(Earaser, SpawnPlace2.transform.position, SpawnPlace2.transform.rotation);
                StartCoroutine(SpawnTimer());
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<Player_Health>().takeDamage(Damage);
        }


    }

    IEnumerator FlopAttackHandle()
    {
        isDashHandler = true;
        canFlop = true;
        yield return new WaitForSeconds(0.9f);
        isDashing = true;
        yield return new WaitForSeconds(0.5f);
        canFlop = false;
        isDashing = false;
        yield return new WaitForSeconds(DashDuration);
        canFlop = true;
        isDashHandler = false;
    }
    IEnumerator SpawnTimer()
    {
        spawenedFuckers = true;
        yield return new WaitForSeconds(5);
        spawenedFuckers = false;
    }
}
