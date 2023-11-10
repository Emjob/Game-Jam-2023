using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : MonoBehaviour
{
    public int Damage;
    public int shielding;

    LayerMask Enemies;

    Character_Movement Ability;
    // Start is called before the first frame update
    void Start()
    {
       Enemies = LayerMask.GetMask("Enemies");
       Ability = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_Movement>();
        if (Ability.bulletShield)
        {
            GameObject.FindWithTag("Player").GetComponent<Player_Health>().Shield(shielding);
        }

        

        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, 100f, Enemies);

        // For each object that the raycast hits.
        foreach (RaycastHit hit in hits)
        {

            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("AHDUAHSBDJHBFA");
            }
        }

        }

    // Update is called once per frame
    void Update()
    {
        

    }

    void OnTriggerEnter(Collider other)
    {
       
    }
}
