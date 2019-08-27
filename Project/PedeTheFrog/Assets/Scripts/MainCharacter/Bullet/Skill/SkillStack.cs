using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillStack : MonoBehaviour
{
    public Image imageStack;
    public int skillNumber;
    bool isStack = false;

    float curStack = 0;

    public void IncreaseStackSkill(int num)
    {
        SkillBtnManager skillBtnManager = GameObject.Find("CharacterControl").GetComponent<SkillBtnManager>();
        float tmp = (float)skillBtnManager.Skills[num] / 3f;
        imageStack.fillAmount = tmp;
    }

    public void DecreaseStackSkill()
    {
        SkillBtnManager skillBtnManager = GameObject.Find("CharacterControl").GetComponent<SkillBtnManager>();
        float tmp = (float)skillBtnManager.Skills[skillNumber] / 3f;
        imageStack.fillAmount = tmp;
    }
}
