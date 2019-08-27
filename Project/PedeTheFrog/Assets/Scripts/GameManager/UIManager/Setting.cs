using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Setting : MonoBehaviour
{
    public AudioMixer m_audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void settingVolume(float volume)
    {
        m_audioMixer.SetFloat("volume", volume);
    }

    public void settingManager()
    {
        gameObject.SetActive(true);
    }

    public void BackHomeSetting()
    {
        gameObject.SetActive(false);
    }
}
