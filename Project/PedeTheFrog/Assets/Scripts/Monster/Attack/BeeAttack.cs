using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAttack : MonoBehaviour
{
    public MoveRandom moveScript;
    public GameObject indicatorVFX;
    public GameObject skillVFX;
    public AudioSource source;
    public float indicator;
    public float skillSpeed;
    public float attackRange;

    private Transform MCPos;
    private float distanceToTarget;
    private bool isPreping;
    private bool isAttacking;

    private Vector3 direction;
    private Vector3 m_dir;

    public void SkillIndicate()
    {
        indicatorVFX.SetActive(true);
        moveScript.StopMoving();
        isPreping = true;

        Invoke("Attack", indicator);
    }

    public void Attack()
    {
        indicatorVFX.SetActive(false);
        skillVFX.SetActive(true);
        isAttacking = true;
        isPreping = false;
        source.Play();

        CancelInvoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "MC")
        {
            if (isAttacking)
            {
                Invoke("EndAttackPhase", 0.5f);
            }
        }
    }

    private void EndAttackPhase()
    {
        moveScript.StartMoving();
        skillVFX.SetActive(false);
        isAttacking = false;

        CancelInvoke();
    }

    private void Start()
    {
        MCPos = GameObject.Find("character").GetComponent<Transform>();
        isAttacking = false;
        isPreping = false;
    }

    private void FixedUpdate()
    {
        if (isPreping)
        {
            Vector3 targetDir = MCPos.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
        }

        if (isAttacking)
        {
            transform.Translate(Vector3.up * Time.deltaTime * skillSpeed);
        }
    }

    private void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, MCPos.position);

        if ((distanceToTarget < attackRange) && !isAttacking)
        {
            SkillIndicate();
        }
    }
}
