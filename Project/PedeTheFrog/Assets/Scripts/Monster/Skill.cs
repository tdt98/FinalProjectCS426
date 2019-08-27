using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public GameObject m_skill;
    public GameObject m_notification;
    public float m_waitTime;
    private float timeWaiting;
    public bool m_disabled = false;
    // Start is called before the first frame update
    void Start()
    {
        timeWaiting = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float tmpTime = 0;   
        if(timeWaiting <= 0)
        {
            m_disabled = true;
            m_notification.SetActive(false);
            m_skill.SetActive(true);
            timeWaiting = m_waitTime;
            tmpTime = timeWaiting;
        }
        else if (timeWaiting < 1)
        {
            m_notification.SetActive(true);
        }
        else
        {
            if (timeWaiting <= (m_waitTime - 0.6))
            {
                m_disabled = false;
                m_skill.SetActive(false);
            }
        }
        timeWaiting -= Time.deltaTime;
    }
}
