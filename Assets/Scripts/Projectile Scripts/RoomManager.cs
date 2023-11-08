using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private GameObject[] SpawnPoints;
    [SerializeField] private GameObject[] Enemies;
    [Range(1, 6)]
    public int Rounds;

    void Start()
    {
        for(int i = 0; i<SpawnPoints.Length; i++)
        { 
            Enemies[i] = SpawnPoints[i].GetComponent<EnemyLists>().enemies[i];
            Instantiate(Enemies[i],SpawnPoints[i].transform.position,Quaternion.identity);
        }
    }

    
    void Update()
    {
        
    }

    void Spawn(int wave)
    {
        for(int i = 0; i< SpawnPoints.Length; i++)
        {
            //Instantiate(,SpawnPoints[i].transform.position,Quaternion.identity);
        }
    }
}
