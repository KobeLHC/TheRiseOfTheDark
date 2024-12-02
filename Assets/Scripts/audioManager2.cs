using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class audioManager2 : MonoBehaviour
{
    [Header("----- Audio Source ------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("----- Audio Clip ------")]

    public AudioClip soft;
    public AudioClip buttons;


    void Start()
    {
        musicSource.clip = soft;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playSFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void playMusic(AudioClip clip)
    {
        musicSource.Stop();
        musicSource.clip = clip;
        musicSource.Play();
    }
}

