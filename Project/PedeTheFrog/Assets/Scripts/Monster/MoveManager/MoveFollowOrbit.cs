using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFollowOrbit : MonoBehaviour
{
    private Skill skillTemplate;
    public float m_speed;
    public Transform[] m_moveSpots;
    private float waitTime;
    public float m_startWaitTime;
    private int randomSpot;
    // Start is called before the first frame update
    void Start()
    {
        skillTemplate = transform.GetComponent<Skill>();
        waitTime = m_startWaitTime;
        randomSpot = Random.Range(0, m_moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        bool v = skillTemplate.m_disabled;
        if (v != true)
        {
            transform.position = Vector2.MoveTowards(transform.position, m_moveSpots[randomSpot].position, m_speed * Time.deltaTime);
        }
        else
        {
            return;
        }
        if(Vector2.Distance(transform.position, m_moveSpots[randomSpot].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, m_moveSpots.Length);
                waitTime = m_startWaitTime;
            }
            //Waiting time 
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        //change direction 
        Vector2 direction = new Vector2( m_moveSpots[randomSpot].position.x - transform.position.x, m_moveSpots[randomSpot].position.y - transform.position.y);
        transform.up = direction;
    }
}
