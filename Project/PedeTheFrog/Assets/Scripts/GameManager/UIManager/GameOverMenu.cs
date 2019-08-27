using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("UILevel");
    }

    public void BackHome()
    {
        SceneManager.LoadScene("UI");
    }

    public void MenuLevel()
    {
        SceneManager.LoadScene("UILevel");
    }
}
