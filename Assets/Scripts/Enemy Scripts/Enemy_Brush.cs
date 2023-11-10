using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Brush : MonoBehaviour
{
    NavMeshAgent enemy;
    GameObject player;
    public GameObject paint;
    private float nextShotTime;
    public float timeBetweenShots;
    public GameObject BulletPlace;

    [SerializeField] private float awayDistance; 
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Time.time > nextShotTime)
        {
            Instantiate(paint, BulletPlace.transform.position, BulletPlace.transform.rotation);
            nextShotTime = Time.time + timeBetweenShots;
        }
        Debug.Log(gameObject.name + gameObject.GetComponent<Rigidbody>().velocity);
    }
    void Move()
    {
        enemy.SetDestination(player.transform.position);
        enemy.stoppingDistance = awayDistance;
    }
}
