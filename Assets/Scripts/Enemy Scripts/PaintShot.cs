using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintShot : MonoBehaviour
{
    GameObject player;
    [SerializeField] private float speed = 30f;
    public int Damage;
    private bool noHit;

    IEnumerator DestroyBulletAfterTime()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !noHit)
        {
            player.GetComponent<Player_Health>().takeDamage(Damage);
            noHit = true;
        }


    }
    private void OnEnable()
    {

        StartCoroutine(DestroyBulletAfterTime());

    }

}
