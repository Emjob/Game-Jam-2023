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
        Ammo = 1;
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
      switch(Ammo)
      {
        case 1:
        Debug.Log("RED");
        Ammo++;
        break;

        case 2:
        Debug.Log("BLUE");
        Ammo++;
        break;
        
        case 3:
        Debug.Log("GREEN");
        Ammo++;
        break;
        
        case 4:
        Debug.Log("BROWN");
        Ammo++;
        break;
        
        case 5:
        Debug.Log("YELLOW");
        Ammo++;
        break;

        case 6:
        Debug.Log("PURPLE");                                                                                                                                                                                                                                                                                                                                               
        Ammo = 1;
        break;
      }

        
    }
    

}
