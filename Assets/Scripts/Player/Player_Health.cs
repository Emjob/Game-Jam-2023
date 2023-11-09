using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth;
    [SerializeField]private int currentHealth;
    public int shield;
    void Start()
    {
      currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(shield > 0)
        {
            StartCoroutine(RemoveShield());
        }
    }

    public void Shield(int getShield)
    {
        if(shield <= 0)
        {
            shield = 0;
            shield += getShield;
        }
    }
    public void Heal(int heal) 
    { 
        if(currentHealth < maxHealth)
        {
            currentHealth += heal;
        }
        
    }

    public IEnumerator RemoveShield()
    {
        yield return new WaitForSeconds(5);
        shield = 0;
    }
}
