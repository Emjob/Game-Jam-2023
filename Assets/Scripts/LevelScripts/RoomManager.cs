using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private GameObject[] SpawnPoints;
    private int round;
    public bool progress;
    [SerializeField] private int maxRounds;
    [SerializeField] private GameObject Door;
    private bool begun;
    [SerializeField] private GameObject[] Enemies = new GameObject[2];


    void Start()
    {
        Spawn();
    }


    void Update()
    {

            for(int i = 0; i< Enemies.Length;  i++) 
            {
                Enemies = GameObject.FindGameObjectsWithTag("Enemy");
                if (Enemies.Length == 0 )
                {
                    round++;
                    Spawn();
                    Enemies = GameObject.FindGameObjectsWithTag("Enemy");
                }
            }
    }

    void Spawn()
    {
        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            Instantiate(SpawnPoints[i].GetComponent<EnemySpawns>().enemies[round], SpawnPoints[i].transform.position, Quaternion.identity);
        }

        Debug.Log(round);
    
    }


}
