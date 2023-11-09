using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth;
    [SerializeField]private int currentHealth;
    void Start()
    {
     //  maxHealth = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Heal(int heal) 
    { 
        if(currentHealth < maxHealth)
        {
            currentHealth += heal;
        }
        
    }

}
