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
        if (other.tag != "Player" && other.tag != "Explosion" && other.tag != "Enemy")
        {
            Destroy(gameObject);

        }
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy_Health>().takeDamage(Damage);
        }
        if (other.tag != "Explosion")
        {
            GameObject Explode = Instantiate(Explosion, this.transform.position, Quaternion.identity);
            Explode.GetComponent<Explode>().enabled = true;
        }

    }
}
