using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    private bool bossOn = false;

    public UIFill checkSoul;
    private bool fullSoul = false;

    public Image moon;
    public Image boss;

    private bool redMoonTimerEnd;

    [SerializeField] TextMeshProUGUI grassRemainText;
    public levelUpMenu unlockGrass;
    public shootGrass grassRemain;
    public GameObject grassLogo;

    public enemySpawn spawnBoss;
    private bool spawned;

    //Audio
    audioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>();
    }

    void Start()
    {
        moon.enabled = true;
        boss.enabled = false;
        redMoonTimerEnd = false;

        grassRemainText.gameObject.SetActive(false);
        grassLogo.SetActive(false);
        spawned = false;

    }

    void Update()
    {
        
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quit game");
            quitGame();
        }*/

        //Reload Scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            audioManager.playSFX(audioManager.buttons);
            audioManager.playMusic(audioManager.background);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1.0f;
        }

        if (bossOn == false)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }

            else if(remainingTime <= 0)
            {
                redMoonTimerEnd = true;
                fullSoul = checkSoul.isFull();

                if (spawned == false)
                {
                    spawnBoss.spawn();
                    spawned = true;
                }

                remainingTime = 0;
                StartCoroutine(bossFightOn());
            }
        }

        else if(bossOn == true)
        {
            if (remainingTime > 0)
            {
                //first losing condition -- HP/Soul Jar <= 0
                if(checkSoul.fill.fillAmount <= 0)
                {
                    //Debug.Log("Quit game");
                    audioManager.playSFX(audioManager.pDeath);
                    loseScene();
                }

                remainingTime -= Time.deltaTime;
            }

            //Second losing condition -- remaining time = 0
            else if (remainingTime == 0)
            {
                //remainingTime = 0;
                loseScene();
            }
        }
  
        //Showing Timer on screen
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        //Apears grass remaining on screen
        if(unlockGrass.sentUnlockG() == true)
        {
            //Debug.Log("Success unlock");
            grassRemainText.text = string.Format("x " + grassRemain.getGrassRemain());
            grassLogo.SetActive(true);
            grassRemainText.gameObject.SetActive(true);
        }
    }

    private IEnumerator bossFightOn()
    {
        yield return new WaitForSeconds(1);
        moon.enabled = false;
        boss.enabled = true;
        bossOn = true;
        remainingTime = 90;
    }

    private void loseScene()
    {
        audioManager.playSFX(audioManager.endLose);
        SceneManager.LoadSceneAsync("Lose");
    }

    //Check if player fufill the power up requirement before red moon ends
    public bool getFullSoul()
    {
        return fullSoul;
    }

    //Get red moon timer end bool for trigger boss spawn
    public bool getRedMoonTimerEnd()
    { 
            return redMoonTimerEnd;
    }

    public void setFullSoul(bool value)
    {
        fullSoul = value;
    }

    public bool getBossOn()
    {
        return bossOn;
    }

}
