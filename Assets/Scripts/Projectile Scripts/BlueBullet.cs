using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlueBullet : MonoBehaviour
{
    public int Damage;
    public int shielding;

    public string color = "Blue";

    LayerMask Enemies;

    Character_Movement Ability;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyMe());
       Enemies = LayerMask.GetMask("Enemies");
       Ability = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_Movement>();
        if (Ability.bulletShield)
        {
            GameObject.FindWithTag("Player").GetComponent<Player_Health>().Shield(shielding);
        }

       
        
        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, 12f, Enemies);

        // For each object that the raycast hits.
        foreach (RaycastHit hit in hits)
        {

            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<Enemy_Health>().takeDamage(Damage);
            //    Debug.DrawRay(transform.position, transform.forward, Color.blue,10,true);
             //   Debug.Log("AHDUAHSBDJHBFA");
            }
        }

        }

    // Update is called once per frame
    void Update()
    {
        

    }
    public IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
       
    }
    
}
