using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Handle : MonoBehaviour
{
    public Animator m_animator;
    public float m_health;
    public float m_moveSpeed;
    public float m_timeSpawn;
    public bool m_attack;
    public float m_attackStep;
    private CharacterBehaviour mCharacter;
    
    private Behaviour bossParent;
    float TimeDelay;
    float time = 0;
    bool checkTime;
    float healthTmp;
    // Start is called before the first frame update
    void Start()
    {
        healthTmp = m_health;
        TimeDelay = 0;
        m_attack = false;
        checkTime = false;
        m_attackStep = 0;
        mCharacter = GameObject.FindGameObjectWithTag("MC").GetComponent<CharacterBehaviour>();
        bossParent = GameObject.FindGameObjectWithTag("BossParent").GetComponent<Behaviour>();
        bossParent.m_bgHealth.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //turn off animation attack
        if(checkTime == true)
        {
            time += Time.deltaTime;
        }
        
        if (time >= 1f)
        {
            m_animator.SetBool("attackTrigger", false);
            checkTime = false;
            time = 0f;
        }
        //set direction attack
        if (m_attack && TimeDelay >= m_timeSpawn)
        {
            m_animator.SetBool("attackTrigger", true);
            if (m_animator.GetBool("attackTrigger") == true)
            {
                m_attackStep += 1;
                //set number step attack
                if (m_attackStep >= 4)
                {
                    bossParent.SpawnItem(transform);
                    m_attackStep = 0;
                }
                else
                {
                    bossParent.SpawnItemRockSmall(transform);
                }
                m_attack = false;
                checkTime = true;
                TimeDelay = 0f;
            }
        }
        
        TimeDelay += Time.deltaTime;
        if(bossParent.m_die == true)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        gameObject.GetComponentInChildren<BossTriggerController>().GetDetect();
        if(m_attack == false)
        {
            if (gameObject.GetComponentInChildren<BossTriggerController>().GetDetect() == true)
            {
                Vector3 targetDir = mCharacter.transform.position - transform.position;
                float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
                m_attack = true;
            }
            transform.Translate(Vector3.up * Time.deltaTime * m_moveSpeed);
        }
    }

    public void SpawnRockBreak(Transform a)
    {
        //spawn Item break
        Instantiate(bossParent.m_rockBreak2, a.position, Quaternion.Euler(0, 0, 45));
        Instantiate(bossParent.m_rockBreak2, a.position, Quaternion.Euler(0, 0, 45 + 90));
        Instantiate(bossParent.m_rockBreak2, a.position, Quaternion.Euler(0, 0, 45 + 180));
        Instantiate(bossParent.m_rockBreak2, a.position, Quaternion.Euler(0, 0, 315));
    }

    //blood when it was attacked by MC
    public void TakeDamage(float amount)
    {
        healthTmp -= amount;
        bossParent.m_healthBar.fillAmount = healthTmp / m_health;
        if(healthTmp <= 0)
        {
            bossParent.m_bgHealth.SetActive(false);
            bossParent.m_treasure.SetActive(true);
            bossParent.m_treasure.transform.position = transform.position;
            //Debug.Log("Die");
        }
    }
}
