using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTemplateGenerator : MonoBehaviour
{
    public GameObject[] m_gameObjectTemplate;
    private int rand;

    private void Start()
    {
        rand = Random.Range(0, m_gameObjectTemplate.Length);
        Instantiate(m_gameObjectTemplate[rand], transform.position, Quaternion.identity);
    }
}
