using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintShot : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
   
    IEnumerator DestroyBulletAfterTime()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Player
        Destroy(gameObject);
    }
    private void OnEnable()
    {

        StartCoroutine(DestroyBulletAfterTime());

    }

}
