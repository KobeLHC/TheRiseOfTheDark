using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControl : MonoBehaviour
{
    //Audio
    audioManager2 audioManager2;

    private void Awake()
    {
        audioManager2 = GameObject.FindGameObjectWithTag("Audio2").GetComponent<audioManager2>();

    }

    void Start()
    {
        
    }

    void Update()
    {
     
    }

    public void playGame()
    {
        audioManager2.playSFX(audioManager2.buttons);
        SceneManager.LoadSceneAsync("SampleScene");
        Time.timeScale = 1.0f;
    }

    public void toGamePlay()
    {
        audioManager2.playSFX(audioManager2.buttons);
        SceneManager.LoadSceneAsync("Game Play");
    }

    public void optionMenu()
    {
        audioManager2.playSFX(audioManager2.buttons);
        SceneManager.LoadSceneAsync("Option");
    }

    public void creditMenu()
    {
        audioManager2.playSFX(audioManager2.buttons);
        SceneManager.LoadSceneAsync("Credits");
    }

    public void backMain()
    {
        audioManager2.playSFX(audioManager2.buttons);
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void quitGame()
    {
        audioManager2.playSFX(audioManager2.buttons);
        Application.Quit();
    }

    public void toGear()
    {
        audioManager2.playSFX(audioManager2.buttons);
        SceneManager.LoadSceneAsync("Gear");
    }

    public void backGamePlay()
    {
        audioManager2.playSFX(audioManager2.buttons);
        SceneManager.LoadSceneAsync("Game Play");
    }

    public void toEnemy()
    {
        audioManager2.playSFX(audioManager2.buttons);
        SceneManager.LoadSceneAsync("Enemy");
    }

    public void backGear()
    {
        audioManager2.playSFX(audioManager2.buttons);
        SceneManager.LoadSceneAsync("Gear");
    }

    public void backOption()
    {
        audioManager2.playSFX(audioManager2.buttons);
        SceneManager.LoadSceneAsync("Option");
    }
}
