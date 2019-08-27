using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Behaviour : MonoBehaviour
{
    public GameObject m_boss;
    public GameObject m_spot;
    public GameObject m_item;
    public GameObject m_rockBreak1;
    public GameObject m_rockBreak2;
    public GameObject m_treasure;
    public GameObject m_bgHealth;
    public Image m_healthBar;

    public bool m_die;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(m_boss, m_spot.transform.position, Quaternion.identity);
        m_bgHealth.SetActive(false);
        m_treasure.SetActive(false);
        m_die = false;
    }

    // Update is called once per frame
    void Update()
    {
        //m_spot.transform.position = m_boss.transform.position;
        if(m_healthBar.fillAmount <= 0)
        {
            m_die = true;
        }
    }
    public void SpawnItem(Transform a)
    {
        //spawn Item
        Instantiate(m_item, a.position, Quaternion.identity);
    }
    public void SpawnItemRockSmall(Transform a)
    {
        //spawn Item
        Instantiate(m_rockBreak1, a.position, Quaternion.Euler(0, 0, 45));
        Instantiate(m_rockBreak1, a.position, Quaternion.Euler(0, 0, 0));
        Instantiate(m_rockBreak1, a.position, Quaternion.Euler(0, 0, 315));
    }
}
