using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Gun : MonoBehaviour
{

    [SerializeField]public List<GameObject> Bullet;
    public List<string> BulletNames = new List<string>(6);
    [SerializeField] private GameObject normalBullet;

    public Transform GunEnd;
    private GameObject bulletInstance;

    public int bulletSpeed;

    public Camera cam;

    public string Loaded;
    private int currentBullet;
    private int chamberIndex = 5;
    private int Ammo;
    [SerializeField]private Transform Revolver;

    bool lerp = true;
    float lookSpeed = 100;
    
    void Start()
    {
        for (int i = 0; i < Bullet.Count; i++)
        {
            BulletNames.Add(Bullet[i].name);
        }
        Ammo = 1;
     //   Bullet = GameObject.FindGameObjectsWithTag("Bullet");
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(transform.up, transform.position);
        float dist = Vector3.Distance(Camera.main.transform.position, transform.position);
        plane.Raycast(ray, out dist);

        Quaternion rotation = transform.rotation;
        transform.LookAt(ray.GetPoint(dist));
        if (lerp)
        {
            transform.rotation = Quaternion.Slerp(rotation, transform.rotation, lookSpeed * Time.deltaTime);
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Bullet.RemoveAt(chamberIndex);
            Bullet.Add(normalBullet);
            chamberIndex--;
            listUpdates();
        }
        if(Input.GetMouseButtonDown(0))
        { 
            Shoot(Ammo);
        }
        
        Loaded = Bullet[currentBullet].name;
     //   Debug.Log(GunEnd.transform.forward * 1000);
    }
    private void Shoot(int Round)
    {
      switch(Ammo)
      {
        case 1:
        currentBullet = 0;
        bulletInstance = Instantiate(Bullet[currentBullet], GunEnd.position, GunEnd.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(GunEnd.transform.forward * bulletSpeed); 
        Debug.Log("RED");
        Ammo++;
        break;
                
        case 2:
        currentBullet++;
        bulletInstance = Instantiate(Bullet[currentBullet], GunEnd.position, GunEnd.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(GunEnd.transform.forward * bulletSpeed);
        Debug.Log("BLUE");
        Ammo++;
        break;
        
        case 3:
        currentBullet++;
        bulletInstance = Instantiate(Bullet[currentBullet], GunEnd.position, GunEnd.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(GunEnd.transform.forward * bulletSpeed);
        Debug.Log("GREEN");
        Ammo++;
        break;
        
        case 4:
        currentBullet++;
        bulletInstance = Instantiate(Bullet[currentBullet], GunEnd.position, GunEnd.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(GunEnd.transform.forward * bulletSpeed);
        Debug.Log("BROWN");
        Ammo++;
        break;
        
        case 5:
        currentBullet++;
        bulletInstance = Instantiate(Bullet[currentBullet], GunEnd.position, GunEnd.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(GunEnd.transform.forward * bulletSpeed);
        Debug.Log("YELLOW");
        Ammo++;
        break;

        case 6:
        currentBullet++;
        bulletInstance = Instantiate(Bullet[currentBullet], GunEnd.position, GunEnd.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(GunEnd.transform.forward * bulletSpeed);
        Debug.Log("PURPLE");                                                                                                                                                                                                                                                                                                                                               
        Ammo = 1;
        break;
      } 
    }
    private void listUpdates()
    {
        BulletNames.Clear();
        for (int i = 0; i < Bullet.Count; i++)
        {
            BulletNames.Add(Bullet[i].name);
        }
    }
   

    
}
