using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private MoveRandomFollowMC parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.FindGameObjectWithTag("Monster").GetComponent<MoveRandomFollowMC>();
    }

    // Update is called once per frame
    void Update()
    {
        string nameNode = gameObject.name;
        if(parent != null)
        {
            if (nameNode == "Boss(Clone)" && parent.m_attacking == true)
            {
                Debug.Log(nameNode);
            }
        }
    }
}
