using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAngry : MonoBehaviour
{
    public float m_speed;
    public float m_lengthMove;
    private Handle mBoss;
    bool Stopped;
    bool Moving;
    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        Moving = false;
        Stopped = false;
        mBoss = GameObject.FindGameObjectWithTag("BossHold").GetComponent<Handle>();
    }
    private void Update()
    {
        if (Stopped == true)
        {
            time += Time.deltaTime;
            if (time >= 0.25f)
            {
                mBoss.SpawnRockBreak(transform);
                Destroy(this.gameObject);
            }
        }


        if (mBoss != null)
        {
            //check one item moved
            if (Stopped == false)
            {
                transform.Translate(Vector2.up * Time.deltaTime * m_speed);
            }
            //check item moving
            if (Moving == false)
            {
                transform.rotation = mBoss.transform.rotation;
                Moving = true;
            }

            float lengthX = Mathf.Abs(transform.position.x - mBoss.transform.position.x);
            float lengthY = Mathf.Abs(transform.position.y - mBoss.transform.position.y);
            float length = Mathf.Sqrt(lengthX * lengthX + lengthY * lengthY);
            if (length >= m_lengthMove && Stopped == false)
            {
                Stopped = true;
                transform.tag = "ItemOfBoss";
            }
        }
    }
}
