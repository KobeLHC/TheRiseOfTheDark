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

    void Start()
    {
        moon.enabled = true;
        boss.enabled = false;
        //checkSoul = GetComponent<UIFill>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitGame();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (bossOn == false)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else if(remainingTime <= 0)
            {
                remainingTime = 0;
                fullSoul = checkSoul.isFull();
                StartCoroutine(bossFightOn());
            }
        }

        else if(bossOn == true)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else if (remainingTime < 0)
            {
                remainingTime = 0;
                quitGame();
            }
        }
  

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private IEnumerator bossFightOn()
    {
        yield return new WaitForSeconds(1);
        moon.enabled = false;
        boss.enabled = true;
        bossOn = true;
        remainingTime = 90;
    }
    private void quitGame()
    {
        Application.Quit();
    }

    public bool getFullSoul()
    {
        return fullSoul;
    }
}
