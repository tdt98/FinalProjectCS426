using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAttack : MonoBehaviour
{
    public Animator animator;
    public SpiderMove moveScript;
    public GameObject web;
    public float coolDown;
    public float delay;

    private float m_coolDown;

    private void Attack()
    {
        moveScript.StopMoving();
        animator.SetBool("Laying", true);

        Invoke("CancelAttack", delay);
    }

    private void CancelAttack()
    {
        Instantiate(web, gameObject.transform.position, Quaternion.identity);
        animator.SetBool("Laying", false);
        moveScript.StartMoving();
        m_coolDown = coolDown;

        CancelInvoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_coolDown = coolDown;
        animator.SetBool("Laying", false);
    }

    // Update is called once per frame
    void Update()
    {
        m_coolDown -= Time.deltaTime;

        if (m_coolDown < 0)
        {
            Attack();
        }
    }
}
