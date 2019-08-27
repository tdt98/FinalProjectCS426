using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButton : MonoBehaviour
{
    public GameObject m_on;
    public GameObject m_off;
    private GameMenuPause buttonJoystick;
    // Start is called before the first frame update
    void Start()
    {
        buttonJoystick = GameObject.FindGameObjectWithTag("UIGameOver").GetComponent<GameMenuPause>();
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonJoystick.btn_Joystick == false)
        {
            m_on.SetActive(true);
            m_off.SetActive(false);
        }
        else
        {
            m_on.SetActive(false);
            m_off.SetActive(true);
        }
    }

    
}
