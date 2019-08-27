using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSpawner : MonoBehaviour
{
    public bool m_rotated;
    //true = rotate 90 degree
    //false = do not rotate

    public GameObject m_doors;

    private bool spawnedDoor;

    public float m_timer = 4f;

    private void Start()
    {
        spawnedDoor = false;
        Destroy(gameObject, m_timer);
        Invoke("SpawnDoor", 0.1f);
    }

    void SpawnDoor()
    {
        if(spawnedDoor == false)
        {
            if(m_rotated == true)
            {
                Instantiate(m_doors, transform.position, Quaternion.Euler(0, 0, 90));
            }
            else
            {
                Instantiate(m_doors, transform.position, Quaternion.identity);
            }
            spawnedDoor = true;
        }
    }
}
