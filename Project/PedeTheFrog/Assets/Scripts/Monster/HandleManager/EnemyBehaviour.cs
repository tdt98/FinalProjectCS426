using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private bool isDeadMonster = false;
    public GameObject m_DieEffect;

    public bool IsDeadMonster
    {
        get
        {
            return isDeadMonster;
        }
        set
        {
            isDeadMonster = value;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Instantiate(m_DieEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.tag == "Tongue")
        {
            isDeadMonster = true;
        }
    }
}
    
