using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy: MonoBehaviour
{
    public GameObject[] m_enemy;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, m_enemy.Length);
        Instantiate(m_enemy[rand], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
