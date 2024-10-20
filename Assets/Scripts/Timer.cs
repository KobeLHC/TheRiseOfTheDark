using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    private bool bossOn = false;

    public Image moon;
    public Image boss;

    void Start()
    {
        moon.enabled = true;
        boss.enabled = false;
    }

    void Update()
    {
        if (bossOn == false)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else if(remainingTime <= 0)
            {
                remainingTime = 0;
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
      UnityEditor.EditorApplication.isPlaying = false;
    }
}
