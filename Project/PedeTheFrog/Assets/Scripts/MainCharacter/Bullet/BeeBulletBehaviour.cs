using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBulletBehaviour : MonoBehaviour
{
    public float speedBullet;
    public float maxRangeBullet;
    private float distanceBullet;
    private Vector3 tartgetPos;
    private Vector3 bulletPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Wall"
            && collision.transform.tag == "BossParent")
        {
            Destroy(gameObject);
        }
    }

    public void ShootBeeBullet(Vector3 target)
    {
        transform.GetComponent<Rigidbody2D>().velocity = new Vector2(speedBullet * (target.x - transform.position.x), speedBullet * (target.y - transform.position.y));
    }

    private void Start()
    {
        bulletPos = transform.position;
    }
    private void FixedUpdate()
    {
        distanceBullet = Mathf.Sqrt(Mathf.Pow((transform.position.x - bulletPos.x), 2) + Mathf.Pow((transform.position.y - bulletPos.y), 2));
        if (distanceBullet > maxRangeBullet)
        {
            Destroy(gameObject);
        }
    }
}
