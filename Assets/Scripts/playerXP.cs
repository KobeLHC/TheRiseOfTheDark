using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class playerXP : MonoBehaviour
{
    public Slider XPBar;
    [SerializeField] private levelUpMenu menuUp;
    private bool showOnce;

    void Start()
    {

        if (menuUp == null)
        {
            GameObject menuObject = GameObject.Find("Level Up Menu");
            if (menuObject != null)
            {
                menuUp = menuObject.GetComponent<levelUpMenu>();
            }

            if (menuUp == null)
            {
                Debug.LogWarning("Level Up Menu not found!");
            }
            
        }
        showOnce = false;
        
    }

    void Update()
    {
        if (menuUp.sentFireLv() == 5 && menuUp.sentWaterLv() == 5 && menuUp.sentGrassCoolDown() == 5 && showOnce == false)
        {
            showOnce = true;
            menuUp.pauseGame();
            XPBar.value += XPBar.maxValue;
        }
    }

    public void addXP(int xp)
    {
        if (menuUp.sentFireLv() == 5 && menuUp.sentWaterLv() == 5 && menuUp.sentGrassCoolDown() == 5)
        {

        }

        else
        {
            XPBar.value += xp;

            if (XPBar.value >= XPBar.maxValue)
            {
                XPBar.value = 0;
                if (menuUp != null)
                {
                    menuUp.pauseGame();
                }
            }
        }
    }

    public bool getShowOnce()
    {
        return showOnce;
    }
}
