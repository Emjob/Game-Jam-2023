using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PaintBucketBoss : MonoBehaviour
{
    NavMeshAgent enemy;
    GameObject player;
    public GameObject paint;
    private float nextShotTime;
    public float timeBetweenShots;
    public GameObject BulletPlace;
    public Gun gun;
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
            Instantiate(paint, BulletPlace.transform.position, BulletPlace.transform.rotation);
            nextShotTime = Time.time + timeBetweenShots;
        }
        if (GetComponent<Enemy_Health>().health <= 0)
        {
            gun.RemoveBullet();
        }
    }

}
