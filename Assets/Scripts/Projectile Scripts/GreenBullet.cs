using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBullet : MonoBehaviour
{
    public int Damage;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
