using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private GameObject[] SpawnPoints;
    //[Range(1, 6)]
    //public int Rounds;
    private int round;
    public bool progress;

    void Start()
    {

    }


    void Update()
    {
        if (progress)
        {
            round++;
            progress = false;
        }
    }



    void Spawn()
    {
        // Debug.Log(SpawnPoints[0].GetComponent<EnemyLists>().test);

        for (int i = 0; i < SpawnPoints.Length - 1; i++)
        {
            Instantiate(SpawnPoints[i].GetComponent<EnemyLists>().enemies[round], SpawnPoints[i].transform.position, Quaternion.identity);
        }

        Debug.Log(round);

    }
}
