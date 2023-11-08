using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField]private GameObject[] Bullet;
    public string Loaded;
    private int currentBullet;
    private int Ammo;
    [SerializeField]private Transform Revolver;

    void Start()
    {
        Ammo = 1;
     //   Bullet = GameObject.FindGameObjectsWithTag("Bullet");
    }

    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            Shoot(Ammo);
        }
        Loaded = Bullet[currentBullet].name;
    }
    private void Shoot(int Round)
    {
      switch(Ammo)
      {
        case 1:
        currentBullet = 0;
        Debug.Log("RED");
        Ammo++;
        break;

        case 2:
        currentBullet++;
        Debug.Log("BLUE");
        Ammo++;
        break;
        
        case 3:
        currentBullet++;
        Debug.Log("GREEN");
        Ammo++;
        break;
        
        case 4:
        currentBullet++;
        Debug.Log("BROWN");
        Ammo++;
        break;
        
        case 5:
        currentBullet++;
        Debug.Log("YELLOW");
        Ammo++;
        break;

        case 6:
        currentBullet++;
        Debug.Log("PURPLE");                                                                                                                                                                                                                                                                                                                                               
        Ammo = 1;
        break;
      } 
    }  
}
