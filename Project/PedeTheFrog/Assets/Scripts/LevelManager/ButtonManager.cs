using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject m_lock;
    public GameObject m_turnOn;
    private LevelManager levelLock;
    // Start is called before the first frame update
    void Start()
    {
        levelLock = GameObject.FindGameObjectWithTag("LevelUI").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(levelLock.checklevel == true)
        {
            unlock();
        }
    }

    public void unlock()
    {
        m_lock.SetActive(false);
        m_turnOn.SetActive(true);
    }
}
