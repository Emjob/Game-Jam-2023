using System.Collections;
using System.Collections.Generic;
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
        Vector3 point = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        // Using some math to calculate the point of intersection between the line going through the camera and the mouse position with the XZ-Plane
        float t = cam.transform.position.y / (cam.transform.position.y - point.y);
        Vector3 finalPoint = new Vector3(t * (point.x - cam.transform.position.x) + cam.transform.position.x, 1, t * (point.z - cam.transform.position.z) + cam.transform.position.z);
        //Rotating the object to that point
        transform.LookAt(finalPoint, Vector3.up);

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
        Debug.Log(GunEnd.transform.forward * 1000);
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
