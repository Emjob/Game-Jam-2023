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

    [SerializeField]private Transform GunEnd;
    [SerializeField] private Transform[] ShotgunBarrel;
    private GameObject bulletInstance;
    LayerMask Enemies;

    public int Damage;
    public RaycastHit[] hits;

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
            if(currentBullet<6)
            {
                currentBullet++;
            }
            if(currentBullet == 6)
            {
                currentBullet = 0;
            }
            Loaded = Bullet[currentBullet].name;
            Shoot(Ammo);
        }
        
        
     //   Debug.Log(GunEnd.transform.forward * 1000);
    }


    private void Shoot(int Round)
    {
      switch(Ammo)
      {
        case 1:
                //currentBullet = 0;
                FireBullet();
                Debug.Log("RED");
                
        break;
                
        case 2:
                //currentBullet++;
                FireBullet();
                Debug.Log("BLUE");
                break;
        
        case 3:
                //currentBullet++;
                FireBullet();
                Debug.Log("GREEN");

        break;
        
        case 4:
                FireBullet();
                Debug.Log("BROWN");
        break;
        
        case 5:
                FireBullet();
                Debug.Log("YELLOW");
        
        break;

        case 6:
                //currentBullet++;
                FireBullet();
                Debug.Log("PURPLE");
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
        Ability.updateAbilities();
        
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
        if (Loaded == "Blue Bullet")
        {
            LAZERbeam();
        }
        else if (Loaded == "Green Bullet")
        {
            FireShotgun();

        }
        else if (Loaded == "Purple Bullet")
        {
            StartCoroutine(BurstFire());
        }
        else
        {
            bulletInstance = Instantiate(Bullet[currentBullet], GunEnd.position, GunEnd.rotation);
            bulletInstance.GetComponent<Rigidbody>().AddForce(GunEnd.transform.forward * bulletSpeed);
        }

    }
    private void LAZERbeam()
    {
        bulletInstance = Instantiate(Bullet[currentBullet], GunEnd.position, GunEnd.rotation);
    }

    private void FireShotgun()
    {
        for (int i = 0; i < ShotgunBarrel.Length; i++)
        {
            bulletInstance = Instantiate(Bullet[currentBullet], ShotgunBarrel[i].position, ShotgunBarrel[i].rotation);
            bulletInstance.GetComponent<Rigidbody>().AddForce(ShotgunBarrel[i].transform.forward * bulletSpeed);
        }
    }
    public IEnumerator BurstFire()
    {
        for (int i = 0; i < 3; i++)
        {
            bulletInstance = Instantiate(Bullet[currentBullet], GunEnd.position, GunEnd.rotation);
            bulletInstance.GetComponent<Rigidbody>().AddForce(GunEnd.transform.forward * bulletSpeed);
            yield return new WaitForSeconds(0.1f);
        }
       
    }

    private void FireBullet()
    {
        if (Loaded == "Blue Bullet")
        {
            LAZERbeam();
        }
        else if (Loaded == "Green Bullet")
        {
            FireShotgun();

        }
        else if (Loaded == "Purple Bullet")
        {
            StartCoroutine(BurstFire());
        }
        else
        {
            bulletInstance = Instantiate(Bullet[currentBullet], GunEnd.position, GunEnd.rotation);
            bulletInstance.GetComponent<Rigidbody>().AddForce(GunEnd.transform.forward * bulletSpeed);
        }
        if (Ability.doubleShot)
        {
            StartCoroutine(DoubleShot());
        }
        
        StartCoroutine(NextBullet());
    }

    
    
}
