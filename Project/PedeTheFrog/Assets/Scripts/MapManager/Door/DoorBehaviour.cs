using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorBehaviour : MonoBehaviour
{
    public GameObject m_loadingScreen;
    public Slider m_slider;

    public bool m_isCheckpoint = false;

    AsyncOperation operation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MC"))
        {
            Time.timeScale = 0f;
            LoadLevel();
        }
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously()
    {
        m_loadingScreen.SetActive(true);

        operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            m_slider.value = operation.progress;

            Debug.Log(operation.progress);

            if (operation.progress == 0.9f)
            {
                m_slider.value = 1f;
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
