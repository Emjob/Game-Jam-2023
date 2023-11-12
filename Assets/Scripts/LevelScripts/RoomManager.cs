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


    void Start()
    {
        Spawn();
    }


    void Update()
    {
        if (round > maxRounds)
        {
            if (progress)
            {
                round++;
                progress = false;
            }
        }
        else if(round == maxRounds) 
        {
            NextRoom();
        }

    }

    }
    void Spawn()
    {
      

        for (int i = 0; i < SpawnPoints.Length - 1; i++)
        {
            Instantiate(SpawnPoints[i].GetComponent<EnemySpawns>().enemies[round], SpawnPoints[i].transform.position, Quaternion.identity);
        }

        Debug.Log(round);

    }

    void NextRoom()
    {
        Door.SetActive(false);   
    }
}
