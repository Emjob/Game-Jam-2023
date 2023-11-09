using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Die());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Die()
    {
        
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
