using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : MonoBehaviour
{
    public int Damage;
    public int shielding;

    Character_Movement Ability;
    // Start is called before the first frame update
    void Start()
    {
       Ability = GameObject.FindWithTag("Player").GetComponent<Character_Movement>();
        if (Ability.bulletShield)
        {
            GameObject.FindWithTag("Player").GetComponent<Player_Health>().Shield(shielding);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Enemy")
        {
            Destroy(this.gameObject);
        }
        else if(other.tag == "Enemy")
        {
            other.GetComponent<Enemy_Health>().takeDamage(Damage);
        }
    }
}
