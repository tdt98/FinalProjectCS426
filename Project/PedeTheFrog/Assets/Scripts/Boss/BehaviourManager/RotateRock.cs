using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRock : MonoBehaviour
{
    public float m_time;
    public float m_speedRotation;

    private RockMove parent;

    float tmpTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.FindGameObjectWithTag("RockChild").GetComponent<RockMove>();
    }

    // Update is called once per frame
    void Update()
    {
        //set time life of rock;
        tmpTime += Time.deltaTime;
        if (tmpTime >= m_time)
        {
            Destroy(this.gameObject);
            tmpTime = 0;
        }
        if (parent.m_stop == false)
        {
            float tmp = transform.position.z + 10;
            transform.Rotate(0, 0, tmp);
        }
    }
}
