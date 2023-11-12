using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth;
    [SerializeField]private int currentHealth;
    public int shield;

   [SerializeField]private Image[] hearts;

    public Sprite full;
    public Sprite empty;

    void Start()
    {
      currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = full;
            }
            else
            {
                hearts[i].sprite = empty;
            }
            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled &= false;
            }
        }

        if (currentHealth == 0)
        {
            Destroy(gameObject);
        }

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if(shield > 0)
        {
            StartCoroutine(RemoveShield());
        }

    }

    public void takeDamage(int damage)
    {
        if(shield != 0)
        {
            shield -= damage;
            if(shield < 0)
            {
                currentHealth += shield;
                shield = 0;
            }
        }
        else
        {
            currentHealth -= damage;
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
