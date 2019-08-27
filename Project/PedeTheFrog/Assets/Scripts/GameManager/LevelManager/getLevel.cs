using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class getLevel : MonoBehaviour
{
    public static getLevel instance = null;

    int levelPassed;
    
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
    }

    public void RestartGamePlay()
    {
        SceneManager.LoadScene(levelPassed);
    }
}
