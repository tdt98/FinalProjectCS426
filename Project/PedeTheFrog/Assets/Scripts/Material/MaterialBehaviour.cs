using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialBehaviour : MonoBehaviour
{
    public int skillPoint;

    private bool isTouchTongue = false;
    public bool IsTouchTongue
    {
        get
        {
            return isTouchTongue;
        }
        set
        {
            isTouchTongue = value;
        }
    }

    private GameObject weapon;

    private Vector2 weaponPos;

    private void FixedUpdate()
    {
        if (skillPoint < 0)
        {
            skillPoint = 0;
        }
        if (isTouchTongue)
        {
            transform.position = Vector2.MoveTowards(transform.position, weaponPos, 20 * Time.deltaTime);
            float distanceWeapon = Mathf.Sqrt(Mathf.Pow((transform.position.x - weaponPos.x), 2) + Mathf.Pow((transform.position.y - weaponPos.y), 2));
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tongue")
        {
            weapon = GameObject.Find("weapon");
            weaponPos = weapon.transform.position;
            isTouchTongue = true;
        }
        if (collision.tag == "Weapon" && isTouchTongue)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Weapon" && isTouchTongue)
        {
            Destroy(gameObject);
        }
    }

}
