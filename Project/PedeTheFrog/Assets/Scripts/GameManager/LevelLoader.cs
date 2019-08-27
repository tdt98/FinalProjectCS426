using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject m_loadingScreen;
    public Slider m_slider;

    private AudioManager audioManager;

    AsyncOperation operation;

    public void LoadLevel()
    {
        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously ()
    {
        m_loadingScreen.SetActive(true);

        operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            m_slider.value = operation.progress;

            if(operation.progress == 0.9f)
            {
                m_slider.value = 1f;
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    private void Start()
    {
        
    }
}
