using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandom : MonoBehaviour
{
    public float m_moveSpeed;
    public Vector3 m_dir;
    public float m_turnSpeed;
    public float m_maxX;
    public float m_maxY;

    float targetAngle;
    Vector3 currentPos;
    bool play = true;
    bool movable = false;
    Vector3 direction;
    float xTmp;
    float yTmp;

    void Start()
    {
        xTmp = transform.position.x;
        yTmp = transform.position.y;
        m_dir = Vector3.up;
        movable = true;
        InvokeRepeating("Start1", 0f, 5f);
    }

    public void Initiate()
    {
        
    }

    public void StartMoving()
    {
        movable = true;
        InvokeRepeating("Start1", 0f, 5f);
    }

    public void StopMoving()
    {
        CancelInvoke();
        movable = false;
    }

    void Start1()
    {
        play = true;
        direction = new Vector3(Random.Range(-m_maxX, m_maxX) + xTmp, Random.Range(-m_maxY, m_maxY) + yTmp, 0); //random position in x and y
    }

    private void FixedUpdate()
    {
        if (movable)
        {
            currentPos = transform.position;//current position of gameObject
            if (play)
            { //calculating direction
                m_dir = direction - currentPos;

                m_dir.z = 0;
                m_dir.Normalize();
                play = false;
            }

            Vector3 target = m_dir * m_moveSpeed + currentPos;  //calculating target position
            transform.position = Vector3.Lerp(currentPos, target, Time.deltaTime);//movement from current position to target position
            targetAngle = Mathf.Atan2(m_dir.y, m_dir.x) * Mathf.Rad2Deg - 90; //angle of rotation of gameobject
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, targetAngle), m_turnSpeed * Time.deltaTime); //rotation from current direction to target direction
        }
    }

    void OnCollisionEnter2D()
    {
        CancelInvoke();//stop call to start1 method
        direction = new Vector3(Random.Range(-m_maxX, m_maxX) + xTmp, Random.Range(-m_maxY, m_maxY) + yTmp, 0); //again provide random position in x and y
        play = true;
    }

    void OnCollisionExit2D()
    {
        InvokeRepeating("Start1", 2f, 5f);
    }
}
