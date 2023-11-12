using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossCrayonPack : MonoBehaviour
{
    public bool CanSpawn;
    public GameObject Crayons;
    public GameObject SpawnPlace;
    public float SpawnTimer;


    private void Start()
    {
        CanSpawn = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (CanSpawn)
        {
            Instantiate(Crayons, SpawnPlace.transform.position, SpawnPlace.transform.rotation);
            
            StartCoroutine(SpawnCD());
        }
    }
    IEnumerator SpawnCD()
    {
        CanSpawn = false;
        yield return new WaitForSeconds(SpawnTimer);
        CanSpawn = true;
    }
}
