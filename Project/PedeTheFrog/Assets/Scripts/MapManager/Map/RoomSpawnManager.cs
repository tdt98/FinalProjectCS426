using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawnManager : MonoBehaviour
{
    public int m_nextRoom;
    // 1 = put room lvl 1
    // 2 = put room lvl 2
    // 3 = put room lvl 3
    // 4 = put room lvl 4
    // 5 = put room lvl 5 (boss)

    private RoomTemplateManager template;
    private int rand;
    private bool spawnedRoom = false;

    public float m_timer = 4f;

    void Start()
    {
        spawnedRoom = false;
        Destroy(gameObject, m_timer);
        template = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplateManager>();
        Invoke("SpawnRooms", 0.1f);
    }

    void SpawnRooms()
    {
        if (spawnedRoom == false)
        {
            if (m_nextRoom == 1)
            {
                //spawn lvl 1 room
                Instantiate(template.m_lvl1Rooms, transform.position, template.m_lvl1Rooms.transform.rotation);
            }
            else if (m_nextRoom == 2)
            {
                //spawn lvl 2 room
                Instantiate(template.m_lvl2Rooms, transform.position, template.m_lvl2Rooms.transform.rotation);
            }
            else if (m_nextRoom == 3)
            {
                //spawn lvl 3 room
                Instantiate(template.m_lvl3Rooms, transform.position, template.m_lvl3Rooms.transform.rotation);
            }
            else if (m_nextRoom == 4)
            {
                //spawn lvl 4 room
                Instantiate(template.m_lvl4Rooms, transform.position, template.m_lvl4Rooms.transform.rotation);
            }
            else if (m_nextRoom == 5)
            {
                //spawn lvl 5 room
                Instantiate(template.m_lvl5Rooms, transform.position, template.m_lvl5Rooms.transform.rotation);
            }
            spawnedRoom = true;
        }
    }
}