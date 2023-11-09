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
        if (Time.time > nextShotTime)
        {
            Instantiate(paint, transform.position, Quaternion.identity);
            nextShotTime = Time.time + timeBetweenShots;
        }
        enemy.SetDestination(player.transform.position);
        enemy.stoppingDistance = awayDistance;
    }
}
