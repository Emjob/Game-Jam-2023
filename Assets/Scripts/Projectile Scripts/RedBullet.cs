using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : MonoBehaviour
{
    public int Damage;
    private GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {
        Explosion = GameObject.FindWithTag("Explosion");
        Damage = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        Instantiate(Explosion,this.transform.position,Quaternion.identity);
    }
}
