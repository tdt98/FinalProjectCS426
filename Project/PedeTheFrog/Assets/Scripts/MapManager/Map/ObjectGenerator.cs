using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject[] m_gameObjects;
    private int rand;

    private void Start()
    {
        if(m_gameObjects.Length > 1)
        {
            rand = Random.Range(0, m_gameObjects.Length);
            Instantiate(m_gameObjects[rand], transform.position, Quaternion.identity);
        }
        else Instantiate(m_gameObjects[0], transform.position, Quaternion.identity);
    }
}
