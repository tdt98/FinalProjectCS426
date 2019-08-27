using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossHealthControl : MonoBehaviour
{
    public float m_BossHeath;

    public TMPro.TextMeshPro m_heathPresent;

    
    private void Start()
    {
        m_heathPresent.text = m_BossHeath.ToString();
    }

    private void FixedUpdate()
    {
        if (m_BossHeath <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("BossDeath");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bullet")
        {

            m_BossHeath -= 1;
            m_heathPresent.text = m_BossHeath.ToString();
            Destroy(collision.gameObject);
        }
    }
}
