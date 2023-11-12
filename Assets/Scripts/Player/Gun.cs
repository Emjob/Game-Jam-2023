using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{

    public List<GameObject> Bullet;
    public List<string> BulletNames = new List<string>(6);
    [SerializeField] private GameObject normalBullet;

    [SerializeField] private Transform GunEnd;
    [SerializeField] private Transform[] ShotgunBarrel;
    private GameObject bulletInstance;

    public int bulletSpeed;
    [SerializeField] private int shotCooldown;

    [SerializeField] private Transform[] roundLocations;
    [SerializeField] private List<GameObject> roundImages;
    [SerializeField] private List<GameObject> store;
    public GameObject[] Colurs;
    [SerializeField] private GameObject canvas;

    private float[] distanceToColur;

    public string Loaded;
    private int currentBullet;
    private int chamberIndex = 5;
    private int Ammo;
    public int m = 0;
    private int i = 0;


    bool lerp = false;
    public bool cantShoot;
    float lookSpeed = 100;

    public Character_Movement Ability;

    void Start()
    {
        Sort();
        currentBullet = -1;

        for (int i = 0; i < store.Count; i++)
        {
            GameObject newimage = Instantiate(store[i], Vector3.zero, Quaternion.identity);
            newimage.transform.SetParent(canvas.transform, false);
            newimage.transform.position = roundLocations[i].transform.position;
        }

        for (int i = 0; i < Bullet.Count; i++)
        {
            BulletNames.Add(Bullet[i].name);
        }
        Ammo = 1;
        //   Bullet = GameObject.FindGameObjectsWithTag("Bullet");
    }

    void Update()
    {
        Colurs = GameObject.FindGameObjectsWithTag("Color");

        Debug.Log(store.Count);

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


        if (m >= store.Count - 1)
        {
            Reload();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            RemoveBullet();
        }

        if (Input.GetMouseButtonDown(0) && !cantShoot)
        {
            if (currentBullet < 6)
            {
                currentBullet++;
            }
            if (currentBullet == 6)
            {
                currentBullet = 0;
            }
            Loaded = Bullet[currentBullet].name;
            Shoot(Ammo);
        }

        Sort();
        

    }

    


    private void Shoot(int Round)
    {
        switch (Ammo)
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
        Ability.homing = false;
        cantShoot = true;
        yield return new WaitForSeconds(shotCooldown);
        m++;
        cantShoot = false;
        if (Ammo < 7)
        {
            Ammo++;
        }
        if (Ammo == 7)
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
        
        GameObject.FindWithTag("GunChamber").transform.Rotate(0, 0 ,60);
        
        StartCoroutine(NextBullet());
    }

    float FindDistance(GameObject go, GameObject origin)
    {
        return Vector3.Distance(go.transform.position, origin.transform.position);
    }

    public IEnumerator Reload()
    {
        cantShoot = true;
        m = 0;
         yield return new WaitForSeconds(0.5f);
        for(int k = 0; k < Colurs.Length; k++)
        {
            Colurs[k].GetComponent<Destroy>().DestroyMe();
        }

        for (int i = 0; i < store.Count; i++)
        {
            GameObject newimage = Instantiate(store[i], Vector3.zero, Quaternion.identity);
            newimage.transform.SetParent(canvas.transform, false);
            newimage.transform.position = roundLocations[i].transform.position;
        }
        cantShoot = false;
       
    }

     public void Sort()
    {
        for (int i = 0; i < Bullet.Count; i++)
        {
            for (int j = 0; j < roundImages.Count; j++)
            {
                if (Bullet[i].GetComponent<Color>().color == roundImages[j].name)
                {
                    store[i] = roundImages[j];
                    //  i++;

                }
                //if (i >= Bullet.Count)
                //{
                //    i = 0;
                //}
            }
        }

    }
    public void RemoveBullet()
    {
        Bullet.RemoveAt(chamberIndex);
        Bullet.Add(normalBullet);
        chamberIndex--;
        listUpdates();
    }

}
