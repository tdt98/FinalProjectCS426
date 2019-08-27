using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCooldown : MonoBehaviour
{
    public Image imageCooldown;
    public float cooldown;
    public GameObject buttonNeedCooldown;
    bool isCooldown = false;

    public GameObject cooldownText;

    float curCooldown = 0;

    private void Start()
    {
        imageCooldown.fillAmount = 0;
    }
    private void OnEnable()
    {
        imageCooldown.fillAmount = 0;
    }
    private void FixedUpdate()
    {
        if (isCooldown)
        {
            imageCooldown.fillAmount -= 1 / cooldown * Time.deltaTime;
            buttonNeedCooldown.GetComponent<Button>().interactable = false;
            if (imageCooldown.fillAmount  <= 0)
            {
                imageCooldown.fillAmount = 0;
                isCooldown = false;
                reActiveNode();
            }
            curCooldown -= Time.deltaTime;
            cooldownText.GetComponent<Text>().text = "" + string.Format("{0:0.0}", curCooldown);
        }
    }

    public void activeCooldown()
    {
        this.isCooldown = true;
        imageCooldown.fillAmount = 1;
        cooldownText.SetActive(true);
        curCooldown = cooldown;
    }
    public void reActiveNode()
    {
        buttonNeedCooldown.GetComponent<Button>().interactable = true;
        cooldownText.SetActive(false);
    }
}
