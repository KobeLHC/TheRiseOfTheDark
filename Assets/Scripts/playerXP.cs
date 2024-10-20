using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerXP : MonoBehaviour
{
    public Slider XPBar;
    [SerializeField] private levelUpMenu menuUp;

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
            
            if(menuUp != null)
        {
                menuUp.pauseGame();
            }
        }
    }
}
