using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Brush : MonoBehaviour
{
    NavMeshAgent enemy;
    GameObject player;
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
        enemy.SetDestination(player.transform.position);
        enemy.stoppingDistance = awayDistance;
    }
}
