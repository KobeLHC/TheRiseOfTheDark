using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class bossHP : MonoBehaviour
{
    public Slider HPBar;

    //Audio
    audioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //Winning condition -- Boss HP <= 0
    public void minusHP(int hp)
    {
        HPBar.value -= hp;
        if(HPBar.value <= 0)
        {
            audioManager.playSFX(audioManager.endWin);
            SceneManager.LoadSceneAsync("Win");
        }
    }
}
