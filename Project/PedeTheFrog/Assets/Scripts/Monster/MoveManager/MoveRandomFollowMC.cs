using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandomFollowMC : MonoBehaviour
{
    public float m_moveSpeed;
    public Vector3 m_dir;
    public float m_turnSpeed;
    public float m_maxX;
    public float m_maxY;
    public float m_chaseRange;
    public float m_chaseAttack;
    public bool m_attacking = false;
    public float m_timeDelay = 0;
    
    private CharacterBehaviour mCharacter;
    private ColliderManager mCollider;
    
    Vector3 currentPos;
    Vector3 direction;

    float xTmp;
    float yTmp;
    float i = 0;
    float timeTmp = 0;
    float targetAngle;

    bool play = true;

    void Start()
    {
        mCharacter = GameObject.FindGameObjectWithTag("MC").GetComponent<CharacterBehaviour>();
        mCollider = transform.GetComponent<ColliderManager>();
        xTmp = transform.position.x;
        yTmp = transform.position.y;
        m_dir = Vector3.up;
        InvokeRepeating("Start1", 0f, 5f);
    }
    void Start1()
    {
        timeTmp = m_timeDelay;
        play = true;
        direction = new Vector3(Random.Range(-m_maxX, m_maxX) + xTmp, Random.Range(-m_maxY, m_maxY) + yTmp, 0); //random position in x and y
    }
    void Update()
    {
        string nameNode = gameObject.name;
        //get the distance to the targetand check to see if it is colse enough to chase
        float distanceToTarget = Vector3.Distance(transform.position, mCharacter.transform.position);
        if (distanceToTarget >= m_chaseRange)
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
            i = 0;
        }
        else if(distanceToTarget < m_chaseRange)
        {
            // turn on skill
            if (distanceToTarget < m_chaseAttack && timeTmp <= 0)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                m_attacking = true;
                timeTmp = m_timeDelay;
            }
            else if(m_attacking == false)
            {
                //start chasing the target - turn and move towards the target
                Vector3 targetDir = mCharacter.transform.position - transform.position;
                float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
                transform.Translate(Vector3.up * Time.deltaTime * m_moveSpeed);
                i = 0;

                //calculator time
                timeTmp -= Time.deltaTime;
            }
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