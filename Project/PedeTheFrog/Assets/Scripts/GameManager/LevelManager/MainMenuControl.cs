using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    [System.Serializable]
    public class Level
    {
        public Button m_level;
    }
    public List<Level> m_levelList;
    int levelPassed;
    
    void Start()
    {
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        m_levelList[0].m_level.interactable = true;
        m_levelList[1].m_level.interactable = true;
        m_levelList[2].m_level.interactable = true;
        m_levelList[3].m_level.interactable = true;
        m_levelList[4].m_level.interactable = true;
        switch (levelPassed)
        {
            case 6:
                m_levelList[0].m_level.interactable = true;
                m_levelList[1].m_level.interactable = true;
                break;
            case 8:
                m_levelList[0].m_level.interactable = true;
                m_levelList[1].m_level.interactable = true;
                m_levelList[2].m_level.interactable = true;
                break;
            case 11:
                m_levelList[0].m_level.interactable = true;
                m_levelList[1].m_level.interactable = true;
                m_levelList[2].m_level.interactable = true;
                m_levelList[3].m_level.interactable = true;
                break;
            case 14:
                m_levelList[0].m_level.interactable = true;
                m_levelList[1].m_level.interactable = true;
                m_levelList[2].m_level.interactable = true;
                m_levelList[3].m_level.interactable = true;
                m_levelList[4].m_level.interactable = true;
                break;
        }
    }

    public void LevelToLoad(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void ResetLevel()
    {
        m_levelList[0].m_level.interactable = false;
        m_levelList[1].m_level.interactable = false;
        m_levelList[2].m_level.interactable = false;
        m_levelList[3].m_level.interactable = false;
        PlayerPrefs.DeleteAll();
    }
}
