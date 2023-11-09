using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : MonoBehaviour
{
    public int Damage;
    // Start is called before the first frame update
    void Start()
    {
        Damage = 1;
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
    }
}
