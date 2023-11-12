using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class YellowBullet : MonoBehaviour
{
    public int Damage;
    [SerializeField] private int bounceSpeed;
    [SerializeField] private int bounceCounter;
    private bool StartBounce;

    public string color = "Yellow";

    [SerializeField] private int bulletSpeed;

    Character_Movement Abilities;

    [SerializeField]private float[] distanceToEnemy;

    private Rigidbody rb;

    [SerializeField] private bool startHome;

   [SerializeField] private GameObject a;

    [SerializeField]private GameObject[] enemies;

   
    public int closestIndex, secondIndex;

    
    // Start is called before the first frame update
    void Start()
    {
        Abilities = GameObject.FindWithTag("Player").GetComponent<Character_Movement>();
        if (Abilities.homing)
        {
            float closestDistance = Mathf.Infinity, secondClosest = Mathf.Infinity;
            enemies = GameObject.FindGameObjectsWithTag("Bounce");
            distanceToEnemy = new float[enemies.Length];
            closestIndex = 0;
            secondIndex = 0;

            for (int i = 0; i < enemies.Length; i++)
            {
                distanceToEnemy[i] = FindDistance(enemies[i], this.gameObject); // however you decide to get distance, origin is probably this gameobject?
                if (distanceToEnemy[i] < closestDistance)
                {
                    closestDistance = distanceToEnemy[i];
                    closestIndex = i; // remember which one in the array is closest
                }
                else if (distanceToEnemy[i] < secondClosest)
                {
                    secondClosest = distanceToEnemy[i];
                    secondIndex = i;
                }
            }
            a = enemies[closestIndex];
            StartCoroutine(Homing());
        }
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(StartBounce)
        {
            transform.position = Vector3.MoveTowards(transform.position, a.transform.position, bounceSpeed * Time.deltaTime);

        }
        if(startHome)
        {
            transform.position = Vector3.MoveTowards(transform.position, a.transform.position, bulletSpeed * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            Bounce();
        }
        if(bounceCounter == 3)
        {
            Destroy(gameObject);
        }
    }

    float FindDistance(GameObject go, GameObject origin)
    {
        return Vector3.Distance(go.transform.position, origin.transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Explosion" && other.tag != "Enemy")
        {
            Destroy(gameObject);
            
        }
        if(other.tag == "Enemy")
        {
            startHome = false;
            Bounce();
            other.GetComponent<Enemy_Health>().takeDamage(Damage);
        }
    }

    private void Bounce()
    {
        float closestDistance = Mathf.Infinity, secondClosest = Mathf.Infinity;
        enemies = GameObject.FindGameObjectsWithTag("Bounce");
        distanceToEnemy = new float[enemies.Length];
        closestIndex = 0;
        secondIndex = 0;

        for (int i = 0; i < enemies.Length; i++)
        {
            distanceToEnemy[i] = FindDistance(enemies[i], this.gameObject); // however you decide to get distance, origin is probably this gameobject?
            if (distanceToEnemy[i] < closestDistance)
            {
                closestDistance = distanceToEnemy[i];
                closestIndex = i; // remember which one in the array is closest
            }
            else if (distanceToEnemy[i] < secondClosest)
            {
                secondClosest = distanceToEnemy[i];
                secondIndex = i;
            }
        }
        // now you have all the distances, and can compare them to decide what to do next
        Debug.Log("Closest: " + enemies[closestIndex].name);
        Debug.Log("Second Closest: " + enemies[secondIndex].name);
        a = enemies[secondIndex];
        rb.velocity = Vector3.zero;
        StartBounce = true;
        bounceCounter++;
    }

    public IEnumerator Homing()
    {
        Debug.Log("Start");
        
        yield return new WaitForSeconds(0.1f);
        rb.velocity = Vector3.zero;
        Debug.Log("End");
        startHome = true;
    }


}
