using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPrefabBehaviour : MonoBehaviour
{
    public bool wasWeapon = false;

    public void SetBecomeWeapon(bool value)
    {
        wasWeapon = value;
    }

    public bool IsWeapon()
    {
        return wasWeapon;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Tongue")
        {
            SetBecomeWeapon(true);
        }
    }
}