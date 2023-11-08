using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField]private GameObject[] Bullet;
    private int Ammo;
    [SerializeField]private Transform Revolver;

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot(Ammo);
        }
    }
    private void Shoot(int Round)
    {
        if( Ammo < Bullet.Length)
        {
            //Instantiate(Bullet[Round],)
        Ammo++;
        Debug.Log("Pew");
        }
        else if( Ammo == Bullet.Length)
        {
            Debug.Log( "RELOADING");
            Ammo = 0;
        }
    }
    

}
