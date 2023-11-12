using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunScript : MonoBehaviour
{
    public GameObject player;
    public Transform pTransform;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        pTransform = player.transform;
        transform.LookAt(pTransform);
       
    }
}
