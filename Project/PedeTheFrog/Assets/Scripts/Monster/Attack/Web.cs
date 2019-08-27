using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Web : MonoBehaviour
{
    public float m_time;
    float tmpTime = 0;

    private void Update()
    {
        //set time life of web;
        tmpTime += Time.deltaTime;
        if(tmpTime >= m_time)
        {
            Destroy(this.gameObject);
            tmpTime = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "character")
        {
            Destroy(gameObject);
        }
    }
}
