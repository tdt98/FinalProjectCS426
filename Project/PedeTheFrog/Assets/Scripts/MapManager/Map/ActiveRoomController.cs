using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveRoomController : MonoBehaviour
{
    public GameObject m_enemyContainer;
    public GameObject m_roomTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MC"))
        {
            m_enemyContainer.SetActive(true);
            m_roomTrigger.SetActive(true);
        }
    }
}
