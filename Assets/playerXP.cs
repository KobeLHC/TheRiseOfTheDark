using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerXP : MonoBehaviour
{
    public Slider XPBar;
    private levelUpMenu menuUp;

    void Start()
    {
        GameObject menuUpObject = GameObject.Find("Level Up Menu");
        if (menuUpObject != null)
        {
            menuUp = menuUpObject.GetComponent<levelUpMenu>();
        }
    }

    void Update()
    {
        
    }

    public void addXP(int xp)
    {
        XPBar.value += xp;

        if(XPBar.value >= XPBar.maxValue)
        {
            XPBar.value = 0;
            menuUp.pauseGame();
        }
    }
}
