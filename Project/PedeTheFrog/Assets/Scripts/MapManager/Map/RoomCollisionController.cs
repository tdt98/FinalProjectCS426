using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCollisionController : MonoBehaviour
{
    public int m_enemiesCounter;
    public GameObject m_doors;

    //private GameObject[] doors;

    private void OnTriggerExit2D(Collider2D enemy)
    {
        if (enemy.tag == "Monster"
            || enemy.tag == "ThunderBug"
            || enemy.tag == "Bee"
            || enemy.tag == "Spider"
            || enemy.tag == "BossHold")
        {
            m_enemiesCounter--;
        }

        else if (m_enemiesCounter <= 0)
        {
            m_doors.SetActive(true);
            //doors = GameObject.FindGameObjectsWithTag("Door");

            //foreach (GameObject aDoor in doors)
            //{
            //    //aDoor.GetComponent<DoorBehaviour>().OpenThisDoor();
            //}
            //this.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
