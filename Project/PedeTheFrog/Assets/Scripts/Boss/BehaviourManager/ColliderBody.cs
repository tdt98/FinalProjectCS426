using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBody : MonoBehaviour
{
    public bool m_wasAttacked;

    private Handle body;
    private Boss2 body2;
    // Start is called before the first frame update
    void Start()
    {
        body = GameObject.FindGameObjectWithTag("BossHold").GetComponent<Handle>();
        body2 = GameObject.FindGameObjectWithTag("BossHold").GetComponent<Boss2>();
        m_wasAttacked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(body != null)
        {
            if (m_wasAttacked == true)
            {
                body.TakeDamage(1);
                m_wasAttacked = false;
            }
        }
        if (body2 != null)
        {
            if (m_wasAttacked == true)
            {
                body2.TakeDamage(1);
                m_wasAttacked = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            m_wasAttacked = true;
            Destroy(collision.gameObject);
        }
    }
}
