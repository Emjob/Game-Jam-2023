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
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy_Health>().takeDamage(Damage);
        }
        Destroy(this.gameObject);
        Instantiate(Explosion,this.transform.position,Quaternion.identity);
    }
}
