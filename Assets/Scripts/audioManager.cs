using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    [Header("----- Audio Source ------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("----- Audio Clip ------")]
    public AudioClip background;
    public AudioClip backgroundBoss;

    public AudioClip pAttack;
    public AudioClip fireHit;
    public AudioClip waterHit;
    public AudioClip grassHit;
    public AudioClip buttons;
    public AudioClip endWin;
    public AudioClip endLose;
    public AudioClip pDeath;
    public AudioClip eShortAttack;
    public AudioClip eLongAttackHit;
    public AudioClip bossAttack;
    public AudioClip eDeath;
    public AudioClip pause;
    public AudioClip switchSpell;
    public AudioClip upgrade;



    void Start()
    {
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }

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
        musicSource.loop = true;
        musicSource.Play();
    }
}
