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
    [SerializeField] private int shotCooldown;

    public string Loaded;
    [SerializeField]private int currentBullet;
    private int chamberIndex = 5;
    [SerializeField]private int Ammo;

    bool lerp = false;
    public bool cantShoot;
    float lookSpeed = 100;

    public Character_Movement Ability;
    
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
        if (Input.GetMouseButtonDown(0) && !cantShoot)
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
                if (Ability.doubleShot)
                {
                    StartCoroutine(DoubleShot());
                }
                StartCoroutine(NextBullet());
        break;
                
        case 2:
        currentBullet++;
        bulletInstance = Instantiate(Bullet[currentBullet], GunEnd.position, GunEnd.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(GunEnd.transform.forward * bulletSpeed);
                if (Ability.doubleShot){
                    StartCoroutine(DoubleShot());
                }
        Debug.Log("BLUE");
                StartCoroutine(NextBullet());
                break;
        
        case 3:
        currentBullet++;
        bulletInstance = Instantiate(Bullet[currentBullet], GunEnd.position, GunEnd.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(GunEnd.transform.forward * bulletSpeed);
                if(Ability.doubleShot){
                    StartCoroutine(DoubleShot());
                }
        Debug.Log("GREEN");
        StartCoroutine(NextBullet());
        break;
        
        case 4:
        currentBullet++;
        bulletInstance = Instantiate(Bullet[currentBullet], GunEnd.position, GunEnd.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(GunEnd.transform.forward * bulletSpeed);
                if(Ability.doubleShot){
                    StartCoroutine(DoubleShot());
                }
        Debug.Log("BROWN");
        StartCoroutine(NextBullet());
        break;
        
        case 5:
        currentBullet++;
        bulletInstance = Instantiate(Bullet[currentBullet], GunEnd.position, GunEnd.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(GunEnd.transform.forward * bulletSpeed);
                if (Ability.doubleShot)
                {
                    StartCoroutine(DoubleShot());
                }
                Debug.Log("YELLOW");
        StartCoroutine(NextBullet());
        break;

        case 6:
        currentBullet++;
        bulletInstance = Instantiate(Bullet[currentBullet], GunEnd.position, GunEnd.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(GunEnd.transform.forward * bulletSpeed);
                if (Ability.doubleShot)
                {
                    StartCoroutine(DoubleShot());
                }
                Debug.Log("PURPLE");                                                                                                                                                                                                                                                                                                                                               
        StartCoroutine(NextBullet());
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
    public IEnumerator NextBullet()
    {
        cantShoot = true;
        yield return new WaitForSeconds(shotCooldown);
        cantShoot = false;
        if (Ammo < 7)
        {
            Ammo++;
        }
        if(Ammo == 7)
        {
            Ammo = 1;
        }
        
    }
   
    public IEnumerator DoubleShot()
    {
        
        yield return new WaitForSeconds(0.5f);
        bulletInstance = Instantiate(Bullet[currentBullet], GunEnd.position, GunEnd.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(GunEnd.transform.forward * bulletSpeed);
    }
    
}
