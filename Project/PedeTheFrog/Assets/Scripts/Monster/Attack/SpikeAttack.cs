using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAttack : MonoBehaviour
{
    public MoveRandom movementScript;
    public GameObject spikeTop;
    public GameObject spikeBottom;
    public GameObject spikeLeft;
    public GameObject spikeRight;
    public float coolDown;
    public float skillDelay;

    private Vector3 originalScale;
    private float m_coolDown;
    private float m_skillDelay;
    private bool isAttacking;
    
    private void Indicate()
    {
        isAttacking = true;
        movementScript.StopMoving();
        m_skillDelay = skillDelay;
        Invoke("Attack", skillDelay);
    }

    private void Attack()
    {
        gameObject.transform.localScale = originalScale;

        Instantiate(spikeTop, gameObject.transform.position, Quaternion.identity);
        Instantiate(spikeBottom, gameObject.transform.position, Quaternion.identity);
        Instantiate(spikeLeft, gameObject.transform.position, Quaternion.identity);
        Instantiate(spikeRight, gameObject.transform.position, Quaternion.identity);

        CancelInvoke();
        DoneAttack();
    }

    private void DoneAttack()
    {
        movementScript.StartMoving();
        m_coolDown = coolDown;
        isAttacking = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        originalScale = gameObject.transform.localScale;
        m_coolDown = coolDown;
        m_skillDelay = skillDelay;
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        m_coolDown -= Time.deltaTime;

        if (m_coolDown <= 0)
        {
            m_skillDelay -= Time.deltaTime;

            if (m_skillDelay > 0)
            {
                gameObject.transform.localScale -= new Vector3(0.01f, 0.01f, 0);
            }

            if (!isAttacking)
            {
                Indicate();
            }
        }
    }
}
