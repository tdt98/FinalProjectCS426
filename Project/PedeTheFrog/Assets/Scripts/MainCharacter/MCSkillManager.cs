using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCSkillManager : MonoBehaviour
{
    public GameObject normalBullet;
    public GameObject bossBullet;
    public GameObject thunderBullet;
    public GameObject beeBullet;
    public GameObject spiderBullet;

    private SkillBtnManager skillBtnManager;
    private SkillStack skillStack;
    private int currentSkill;
    private GameObject weapon;
    private GameObject[] bulletArray;
    private GameObject bullet;
    private CharacterBehaviour MC;
    private Vector3 targetPos;

    public void ShootNormalBullet()
    {
        skillBtnManager = GameObject.Find("CharacterControl").GetComponent<SkillBtnManager>();
        MC = GameObject.Find("character").GetComponent<CharacterBehaviour>();
        weapon = GameObject.FindGameObjectWithTag("Weapon");
        bullet = Instantiate(normalBullet, weapon.transform.position, transform.rotation);
        targetPos = MC.Bullets[0];
        bullet.GetComponent<NormalBulletBehaviour>().ShootNormalBullet(targetPos);
        skillBtnManager.Skills[0] -= 1;
    }

    public void ShootBossBullet()
    {
        skillBtnManager = GameObject.Find("CharacterControl").GetComponent<SkillBtnManager>();
        MC = GameObject.Find("character").GetComponent<CharacterBehaviour>();
        weapon = GameObject.FindGameObjectWithTag("Weapon");
        bullet = Instantiate(bossBullet, weapon.transform.position, transform.rotation);
        targetPos = MC.Bullets[0];
        bullet.GetComponent<BossBulletBehaviour>().ShootBossBullet(targetPos);
        skillBtnManager.Skills[1] -= 1;
    }

    public void ShootThunderBullet()
    {
        skillBtnManager = GameObject.Find("CharacterControl").GetComponent<SkillBtnManager>();
        MC = GameObject.Find("character").GetComponent<CharacterBehaviour>();
        weapon = GameObject.FindGameObjectWithTag("Weapon");
        bullet = Instantiate(thunderBullet, weapon.transform.position, transform.rotation);
        bullet.GetComponent<ThunderBulletBehaviour>().ShootThunderBullet();
        skillBtnManager.Skills[2] -= 1;
    }

    public void ShootBeeBullet()
    {
        skillBtnManager = GameObject.Find("CharacterControl").GetComponent<SkillBtnManager>();
        MC = GameObject.Find("character").GetComponent<CharacterBehaviour>();
        weapon = GameObject.FindGameObjectWithTag("Weapon");
        bulletArray = new GameObject[3];
        for (int i = 0; i < 3; i++)
        {
            bulletArray[i] = Instantiate(beeBullet, weapon.transform.position, transform.rotation);
            targetPos = MC.Bullets[i];
            bulletArray[i].GetComponent<BeeBulletBehaviour>().ShootBeeBullet(targetPos);
        }
        skillBtnManager.Skills[3] -= 1;
    }

    public void ShootSpiderBullet()
    {
        skillBtnManager = GameObject.Find("CharacterControl").GetComponent<SkillBtnManager>();
        MC = GameObject.Find("character").GetComponent<CharacterBehaviour>();
        weapon = GameObject.FindGameObjectWithTag("Weapon");
        bullet = Instantiate(spiderBullet, weapon.transform.position, transform.rotation);
        targetPos = MC.Bullets[0];
        bullet.GetComponent<SpiderBulletBehaviour>().ShootSpiderBullet(targetPos);
        skillBtnManager.Skills[4] -= 1;
    }

}