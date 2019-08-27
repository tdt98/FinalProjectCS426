using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBulletBehaviour : MonoBehaviour
{
    public float countdownTime;
    private GameObject MC;

    public void ShootThunderBullet()
    {
        MC = GameObject.Find("character");
        transform.position = MC.transform.position;
    }

    private void FixedUpdate()
    {
        MC = GameObject.Find("character");
        transform.position = MC.transform.position;
        countdownTime -= Time.deltaTime;
        if(countdownTime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "BossParent")
        {
            Destroy(gameObject);
        }
    }
}