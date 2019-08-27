using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggerController : MonoBehaviour
{
    bool detect;
    private Handle mBoss;

    public bool GetDetect()
    {
        return detect;
    }

    private void Start()
    {
        mBoss = GameObject.FindGameObjectWithTag("BossHold").GetComponent<Handle>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MC")
        {
            detect = true;
        }
    }

    private void Update()
    {
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "MC")
        {
            detect = false;
        }
    }
}
