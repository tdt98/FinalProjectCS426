using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip BackGroundMusic;

    private AudioSource source;

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.clip = BackGroundMusic;
        source.loop = true;
        source.volume = 1;
        source.Play();
    }
}
