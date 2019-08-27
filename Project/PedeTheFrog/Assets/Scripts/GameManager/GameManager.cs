using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private CharacterBehaviour mc;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        Application.targetFrameRate = 240;
        mc = GameObject.FindGameObjectWithTag("MC").GetComponent<CharacterBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mc.m_FrogAnimator.GetBool("DeathFlag") == true)
        {
            Invoke("EndGameMenu", 1);
        }
    }
    //set gameover
    public void EndGameMenu()
    {
        SceneManager.LoadScene("Gameover");
    }
}
