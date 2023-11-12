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
    public Gun gun;




    private void Start()
    {
        CanSpawn = true;
        gun = GameObject.FindWithTag("Gun").GetComponent<Gun>();
    }
    // Update is called once per frame
    void Update()
    {
        if (CanSpawn)
        {
            Instantiate(Crayons, SpawnPlace.transform.position, SpawnPlace.transform.rotation);
            
            StartCoroutine(SpawnCD());
        }
        if (GetComponent<Enemy_Health>().health <= 0)
        {
           gun.RemoveBullet();
        }
    }

    IEnumerator SpawnCD()
    {
        CanSpawn = false;
        yield return new WaitForSeconds(SpawnTimer);
        CanSpawn = true;
    }
}
