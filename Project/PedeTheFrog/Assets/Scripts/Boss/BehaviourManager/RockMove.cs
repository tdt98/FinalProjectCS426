using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMove : MonoBehaviour
{
    public GameObject m_child;
    public float m_road;
    public float m_speed;
    public bool m_stop;
    float tmpLength;
    float beginX;
    float beginY;
    // Start is called before the first frame update
    void Start()
    {
        m_stop = false;
        tmpLength = 0;
        beginX = transform.position.x;
        beginY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float lengthX = Mathf.Abs(transform.position.x - beginX);
        float lengthY = Mathf.Abs(transform.position.y - beginY);
        float length = Mathf.Sqrt(lengthX * lengthX + lengthY * lengthY);
        if(length <= m_road)
        {
            transform.Translate(Vector2.up * Time.deltaTime * m_speed);
        }
        else
        {
            m_stop = true;
            m_child.transform.tag = "ItemOfBoss";
        }
    }
}
