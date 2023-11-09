using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int health;
    public int playerHeal;

    Character_Movement Ability;
    // Start is called before the first frame update
    void Start()
    {
        Ability = GameObject.FindWithTag("Player").GetComponent<Character_Movement>();
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
            if (Ability.healOnKill)
            {
                GameObject.FindWithTag("Player").GetComponent<Player_Health>().Heal(playerHeal);
            }
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
