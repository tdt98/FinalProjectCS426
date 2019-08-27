using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CharacterBehaviour : MonoBehaviour
{
    public Transform MC;
    public Transform tongue;
    public Transform weapon;
    private JoystickPlayerExample jpe;
    private WeaponManager weaponManager;

    private bool shootTongueFlag = false;
    private bool collectTongueFlag = false;

    bool shootFlag = true;

    public Animator m_FrogAnimator;

    public float tongueSpeed;
    public float tongueLong;
    public float tongueWidth;

    public float shootSpeed;
    public float shootLength;

    private bool undeadFlag = false;

    public float TimeDelayGameOverMenu;

    public float slowBySpiderWeb;
    public float TimeSlowBySpiderWeb;
    private float defaltMCSpeed;
    public float mcSpeed;
    public float MCSpeed
    {
        get
        {
            return mcSpeed;
        }
        set
        {
            mcSpeed = value;
        }
    }

    private Vector3[] bullets;
    public Vector3[] Bullets
    {
        get
        {
            return bullets;
        }
        set
        {
            bullets = value;
        }
    }

    public Animator FrogAnimator;
    Vector3 targetShoot = new Vector3(-1f, -1f, -1f);
    Vector3 targetCollect;

    Vector3 targetTongueBody;

    void Start()
    {
        tongue.gameObject.SetActive(false);
        defaltMCSpeed = mcSpeed;
        //---
        weaponManager = GameObject.FindGameObjectWithTag("Weapon").GetComponent<WeaponManager>();
        //---
    }

    void FixedUpdate()
    {
        jpe = GameObject.FindGameObjectWithTag("MC").GetComponent<JoystickPlayerExample>();


        if (Input.GetKeyDown(KeyCode.Space))
        {
            shootTongue();
        }

        if (shootTongueFlag == true)
        {
            tongue.position = Vector3.Lerp(tongue.position, targetTongueBody, (tongueSpeed * Time.deltaTime)); /*Slowly moving body tongue to this position*/

            tongue.transform.localScale = new Vector3(tongueWidth, Mathf.Sqrt(Mathf.Pow((tongue.position.y - MC.position.y), 2f) + Mathf.Pow((tongue.position.x - MC.position.x), 2f)) + 0.6f
                , 0f);     /**Scale the body of tongue follow the length of the head toungue**/


            jpe.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll; /*prevent MC from changing positon when shooting tongue*/
            jpe.gameObject.GetComponent<Rigidbody2D>().mass = 10000f; /*change mass to prevent MC moving when be hit by other*/
        }
        if (tongue.position == targetTongueBody) /*the tongue came the that position so set it return to frog*/
        {
            shootTongueFlag = false;
            collectTongue();
        }
        if (collectTongueFlag == true)
        {
            tongue.position = Vector3.Lerp(tongue.position, targetCollect, (tongueSpeed * Time.deltaTime));

            tongue.transform.localScale = new Vector3(tongueWidth, Mathf.Sqrt(Mathf.Pow((tongue.position.y - MC.position.y), 2f) + Mathf.Pow((tongue.position.x - MC.position.x), 2f)) + 0.6f
                    , 0f);  /*Scale the body of tongue follow the length of the head toungue*/
        }
        if (tongue.position == targetCollect)
        {
            tongue.gameObject.SetActive(false);
            collectTongueFlag = false;
            jpe.SetMCMoving();   /*set MC can moving after doing shoot tougue*/
            jpe.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;  /*Allow MC to change positon after shooting tongue*/
            jpe.gameObject.GetComponent<Rigidbody2D>().mass = 1f;
            shootFlag = true;

            tongue.position = MC.position;
            tongue.transform.localScale = new Vector3(0.4f, 0.5f, 0f);

        }

    }

    public void shootTongue()
    {
        if (shootFlag == true && FrogAnimator.GetBool("DeathFlag") == false)    /*Flag to prevent touch shoot tongue many times*/
        {
            jpe.StopMCMoving();
            tongue.Translate(0f, tongueLong / 2, 0f);
            targetTongueBody = tongue.position;
            tongue.Translate(0f, -tongueLong / 2, 0f);
            shootTongueFlag = true;

            tongue.gameObject.SetActive(true);

            shootFlag = false;
        }
    }

    public void UseSkill()
    {
        Vector3 attackTarget = new Vector3(-1f, -1f, -1f);
        bullets = new Vector3[3];
        tongue.Translate(0f, shootLength, 0f);
        attackTarget = tongue.position;
        tongue.Translate(0f, -shootLength, 0f);
        bullets[0] = attackTarget;
        tongue.Translate(2f, shootLength, 0f);
        attackTarget = tongue.position;
        tongue.Translate(-2f, -shootLength, 0f);
        bullets[1] = attackTarget;
        tongue.Translate(-2f, shootLength, 0f);
        attackTarget = tongue.position;
        tongue.Translate(2f, -shootLength, 0f);
        bullets[2] = attackTarget;
    }

    public void collectTongue()
    {
        tongue.Translate(0, -tongueLong / 2, 0);
        targetCollect = MC.position;     /*get target collect*/
        tongue.Translate(0f, tongueLong / 2, 0f);
        collectTongueFlag = true;
    }

    public Vector3 getWeaponPosition()
    {
        return weapon.position;
    }

    public Transform getTmpTongue()
    {
        return weapon;
    }

    public void SetShootFlag(bool value)
    {
        shootFlag = true;
    }

    private void SlowMovingMC()
    {
        mcSpeed = defaltMCSpeed - slowBySpiderWeb;
        Invoke("NormalMovingMC", TimeSlowBySpiderWeb);
    }

    private void NormalMovingMC()
    {
        mcSpeed = defaltMCSpeed;
    }

    public void ChangeUndeadFlag()
    {
        undeadFlag = !undeadFlag;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Monster" || collision.tag == "ThunderBug" || collision.tag == "Spider" || collision.tag == "Bee" || collision.tag == "BossParent" || collision.tag == "RockChild")
            && collision.gameObject.GetComponent<EnemyBehaviour>().IsDeadMonster == false && undeadFlag == false)
        {
            m_FrogAnimator.SetBool("DeathFlag", true);
            //Invoke("TurnOnGameOverMenu", TimeDelayGameOverMenu);
        }
        if (collision.tag == "Skill" && undeadFlag == false || collision.tag == "RockChild" && undeadFlag == false)
        {
            m_FrogAnimator.SetBool("DeathFlag", true);
            //Invoke("TurnOnGameOverMenu", TimeDelayGameOverMenu);
        }
        if (collision.tag == "SpiderWeb")
        {
            SlowMovingMC();
        }
    }
}