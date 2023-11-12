using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEntry : MonoBehaviour
{

    [SerializeField] private GameObject EntryDoor;

    void OnTriggerEnter(Collider other)
    {
        EntryDoor.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
