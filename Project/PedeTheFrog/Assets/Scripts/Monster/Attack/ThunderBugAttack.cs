using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBugAttack : MonoBehaviour
{
    public GameObject IndicatorVFX;
    public GameObject SkillVFX;
    public MoveRandom moveScript;
    public AudioSource source;

    public float coolDown;
    public float indicator;
    public bool m_disabled = false;

    private float skillCountDown;
    private bool isUsingSkill;

    private void Refresh()
    {
        skillCountDown = coolDown;
    }

    private void SkillIndicate()
    {
        if (!SkillVFX.activeInHierarchy)
        {
            IndicatorVFX.SetActive(true);
        }

        Invoke("UseSkill", indicator);
    }

    public void UseSkill()
    {
        moveScript.StopMoving();
        IndicatorVFX.SetActive(false);
        SkillVFX.SetActive(true);
        source.Play();

        Invoke("CancelSkill", coolDown);
    }

    public void CancelSkill()
    {
        SkillVFX.SetActive(false);
        Refresh();
        moveScript.StartMoving();
        CancelInvoke();
    }


    // Start is called before the first frame update
    void Start()
    {
        skillCountDown = coolDown;
    }

    // Update is called once per frame
    void Update()
    {
        skillCountDown -= Time.deltaTime;

        if (skillCountDown <= 0)
        {
            SkillIndicate();
        }
    }
}
