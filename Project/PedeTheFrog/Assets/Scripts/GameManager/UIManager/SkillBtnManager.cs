using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBtnManager : MonoBehaviour
{
    public GameObject tongue;
    public List<GameObject> skillArray;
    private List<int> skills = new List<int>();

    public List<int> Skills
    {
        get
        {
            return skills;
        }
        set
        {
            skills = value;
        }
    }

    private void Start()
    {
        for (int i = 0; i < skillArray.Count; i++)
        {
            skills.Add(0);
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < skills.Count; i++)
        {
            if(skills[i]  > 3)
            {
                skills[i] = 3;
            }
            if (skills[i] > 0)
            {
                skillArray[i].SetActive(true);
                SkillStack skillStack;
                switch (i){
                    case 0:
                        {
                            skillStack = GameObject.Find("NormalSkillStack").GetComponent<SkillStack>();
                            skillStack.IncreaseStackSkill(i);
                        }
                        break;
                    case 1:
                        {
                            skillStack = GameObject.Find("BossSkillStack").GetComponent<SkillStack>();
                            skillStack.IncreaseStackSkill(i);
                        }
                        break;
                    case 2:
                        {
                            skillStack = GameObject.Find("ThunderSkillStack").GetComponent<SkillStack>();
                            skillStack.IncreaseStackSkill(i);
                        }
                        break;
                    case 3:
                        {
                            skillStack = GameObject.Find("BeeSkillStack").GetComponent<SkillStack>();
                            skillStack.IncreaseStackSkill(i);
                        }
                        break;
                    case 4:
                        {
                            skillStack = GameObject.Find("SpiderSkillStack").GetComponent<SkillStack>();
                            skillStack.IncreaseStackSkill(i);
                        }
                        break;
                }
            }
            else
            {
                skillArray[i].SetActive(false);
            }
        }

        if(skills[0] > 0 || skills[1] > 0)
        {
            tongue.SetActive(false);
            if (skills[1] > 0)
            {
                skillArray[0].SetActive(false);
            }
        }
        else
        {
            tongue.SetActive(true);
        }
    }
}