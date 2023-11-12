using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int health;
    public int playerHeal;
    public Gun gun;

    [SerializeField] private float knockbackForce;

    [SerializeField]private float distanceToPlayer;
    public bool isBoss;
    Character_Movement Ability;
    GameObject player;
    // Start is called before the first frame update
     

    void Start()
    {
        Ability = GameObject.FindWithTag("Player").GetComponent<Character_Movement>();
        player = GameObject.FindWithTag("Player");
        gun = GameObject.FindWithTag("Gun").GetComponent<Gun>();


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
            if (isBoss)
            {
                gun.RemoveBullet();
            }

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
    public void KnockBack()
    {
        
        if(distanceToPlayer < 10)
        {
            float a = player.transform.position.x - transform.position.x;
            float b = player.transform.position.z - transform.position.z;
            float knockVelocityX = transform.position.x - a;
            float knockVelocityZ = transform.position.z - b;
            gameObject.GetComponent<Rigidbody>().AddForce(knockVelocityX * knockbackForce,0,knockVelocityZ * knockbackForce);
            Debug.Log("Knock Register");
        }
    }
}
