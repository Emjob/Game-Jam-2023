using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int health;
    public int playerHeal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameObject.FindWithTag("Player").GetComponent<Player_Health>().Heal(playerHeal);
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Explosion")
        {
            takeDamage(other.GetComponent<Explode>().damage);
        }
    }
}
