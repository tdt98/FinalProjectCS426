using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private bool hasBullet;
    public bool HasBullet
    {
        get
        {
            return hasBullet;
        }
        set
        {
            hasBullet = value;
        }
    }

    private int bulletType;
    public int BulletType
    {
        get
        {
            return bulletType;
        }
        set
        {
            bulletType = value;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        SkillBtnManager skillBtnManager = GameObject.Find("CharacterControl").GetComponent<SkillBtnManager>();
        switch (collision.tag)
        {
            case "Leaves":
                {
                    if (collision.gameObject.GetComponent<MaterialBehaviour>().IsTouchTongue)
                    {
                        skillBtnManager.Skills[0] += collision.gameObject.GetComponent<MaterialBehaviour>().skillPoint;
                        collision.gameObject.GetComponent<MaterialBehaviour>().skillPoint -= 1;
                    }
                }
                break;
            case "ItemOfBoss":
                {
                    if (collision.gameObject.GetComponent<MaterialBehaviour>().IsTouchTongue)
                    {
                        skillBtnManager.Skills[1] += collision.gameObject.GetComponent<MaterialBehaviour>().skillPoint;
                        collision.gameObject.GetComponent<MaterialBehaviour>().skillPoint -= 1;
                    }
                }
                break;
            case "ThunderBug":
                {
                    if (collision.gameObject.GetComponent<MaterialBehaviour>().IsTouchTongue)
                    {
                        skillBtnManager.Skills[2] += collision.gameObject.GetComponent<MaterialBehaviour>().skillPoint;
                        collision.gameObject.GetComponent<MaterialBehaviour>().skillPoint -= 1;
                    }
                }
                break;
            case "Bee":
                {
                    if (collision.gameObject.GetComponent<MaterialBehaviour>().IsTouchTongue)
                    {
                        skillBtnManager.Skills[3] += collision.gameObject.GetComponent<MaterialBehaviour>().skillPoint;
                        collision.gameObject.GetComponent<MaterialBehaviour>().skillPoint -= 1;
                    }
                }
                break;
            case "Spider":
                {
                    if (collision.gameObject.GetComponent<MaterialBehaviour>().IsTouchTongue)
                    {
                        skillBtnManager.Skills[4] += collision.gameObject.GetComponent<MaterialBehaviour>().skillPoint;
                        collision.gameObject.GetComponent<MaterialBehaviour>().skillPoint -= 1;
                    }
                }
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        SkillBtnManager skillBtnManager = GameObject.Find("CharacterControl").GetComponent<SkillBtnManager>();
        switch (collision.tag)
        {
            case "Leaves":
                {
                    if (collision.gameObject.GetComponent<MaterialBehaviour>().IsTouchTongue)
                    {
                        skillBtnManager.Skills[0] += collision.gameObject.GetComponent<MaterialBehaviour>().skillPoint;
                        collision.gameObject.GetComponent<MaterialBehaviour>().skillPoint -= 1;
                    }
                }
                break;
            case "ItemOfBoss":
                {
                    if (collision.gameObject.GetComponent<MaterialBehaviour>().IsTouchTongue)
                    {
                        skillBtnManager.Skills[1] += collision.gameObject.GetComponent<MaterialBehaviour>().skillPoint;
                        collision.gameObject.GetComponent<MaterialBehaviour>().skillPoint -= 1;
                    }
                }
                break;
            case "ThunderBug":
                {
                    if (collision.gameObject.GetComponent<MaterialBehaviour>().IsTouchTongue)
                    {
                        skillBtnManager.Skills[2] += collision.gameObject.GetComponent<MaterialBehaviour>().skillPoint;
                        collision.gameObject.GetComponent<MaterialBehaviour>().skillPoint -= 1;
                    }
                }
                break;
            case "Bee":
                {
                    if (collision.gameObject.GetComponent<MaterialBehaviour>().IsTouchTongue)
                    {
                        skillBtnManager.Skills[3] += collision.gameObject.GetComponent<MaterialBehaviour>().skillPoint;
                        collision.gameObject.GetComponent<MaterialBehaviour>().skillPoint -= 1;
                    }
                }
                break;
            case "Spider":
                {
                    if (collision.gameObject.GetComponent<MaterialBehaviour>().IsTouchTongue)
                    {
                        skillBtnManager.Skills[4] += collision.gameObject.GetComponent<MaterialBehaviour>().skillPoint;
                        collision.gameObject.GetComponent<MaterialBehaviour>().skillPoint -= 1;
                    }
                }
                break;
        }
    }
}
