using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameMenuPause : MonoBehaviour
{
    public GameObject m_control;
    public bool btn_Joystick;
    // Start is called before the first frame update
    void Start()
    {
        btn_Joystick = false;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //set game pause
    public void PauseGameMenu()
    {
        m_control.gameObject.SetActive(false);
        gameObject.SetActive(true);
        Time.timeScale = 0f;

    }

    public void changeJoystick()
    {
        btn_Joystick = !btn_Joystick;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        m_control.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene("UILevel");
        m_control.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }

    public void PlayGame()
    {
        gameObject.SetActive(false);
        m_control.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }

    public void BackHome()
    {
        SceneManager.LoadScene("UI");
        m_control.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }
}
