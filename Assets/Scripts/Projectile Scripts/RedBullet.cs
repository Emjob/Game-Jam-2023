using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : MonoBehaviour
{
    public int Damage;
    private GameObject Explosion;
    private bool startHome;

    public string color = "Red";

    Character_Movement Abilities;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Explosion = GameObject.FindWithTag("Explosion");
        Abilities = GameObject.FindWithTag("Player").GetComponent<Character_Movement>();
        if (Abilities.homing)
        {
            float closestDistance = Mathf.Infinity;
            enemies = GameObject.FindGameObjectsWithTag("Bounce");
            distanceToEnemy = new float[enemies.Length];
            closestIndex = 0;
            for (int i = 0; i < enemies.Length; i++)
            {
                distanceToEnemy[i] = FindDistance(enemies[i], this.gameObject); // however you decide to get distance, origin is probably this gameobject?
                if (distanceToEnemy[i] < closestDistance)
                {
                    closestDistance = distanceToEnemy[i];
                    closestIndex = i; // remember which one in the array is closest
                }
                
            }
            a = enemies[closestIndex];
            StartCoroutine(Homing());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startHome)
        {
            transform.position = Vector3.MoveTowards(transform.position, a.transform.position, bulletSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Explosion" && other.tag != "Enemy")
        {
            Destroy(gameObject);

        }
        if (other.tag == "Enemy")
        {
            startHome = false;
            other.GetComponent<Enemy_Health>().takeDamage(Damage);
        }
        if (other.tag != "Explosion")
        {
            GameObject Explode = Instantiate(Explosion, this.transform.position, Quaternion.identity);
            Explode.GetComponent<Explode>().enabled = true;
        }

    }

    public int closestIndex;

    [SerializeField]private int bulletSpeed;

    [SerializeField] private float[] distanceToEnemy;

    private Rigidbody rb;

    [SerializeField] private GameObject a;

    [SerializeField] private GameObject[] enemies;

    float FindDistance(GameObject go, GameObject origin)
    {
        return Vector3.Distance(go.transform.position, origin.transform.position);
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
