using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class levelUpMenu : MonoBehaviour
{
    public GameObject levelupMenu;
    public static bool waitLevelUp;

    //Water control
    private bool unlockedW;
    public GameObject waterScreen;
    private int waterLv = 0; 
    [SerializeField] TextMeshProUGUI waterLvText;

    //Fire control
    public spellControl fire;
    private int fireLv = 0;
    private bool unlockedF;
    [SerializeField] TextMeshProUGUI fireLvText;

    //Grass control
    public GameObject grassScreen;
    private bool unlockedG;
    private int grassLv = 0;
    [SerializeField] TextMeshProUGUI grassLvText;

    public TextMeshProUGUI warningText;
    
   

    void Start()
    {
        levelupMenu.SetActive(false);
        waterScreen.SetActive(true);
        grassScreen.SetActive(true);
        unlockedF = true;
        unlockedW = false;
        unlockedG = false;

        if (fire == null)
        {
            GameObject fireObject = GameObject.Find("Fire Spell LV1");
            if (fireObject != null)
            {
                fire = fireObject.GetComponent<spellControl>();
            }
        }

        GameObject warningObject = GameObject.Find("Warning");
        if (warningObject != null)
        {
            warningText = warningObject.GetComponent<TextMeshProUGUI>();
        }
    }

    void Update()
    {

    }


    public void pauseGame()
    {
        fireLvText.text = string.Format("LEVEL: " + fireLv);
        waterLvText.text = string.Format("LEVEL: " + waterLv);
        grassLvText.text = string.Format("LEVEL: " + grassLv);
        levelupMenu.SetActive(true);
        warningText.gameObject.SetActive(false);
        Time.timeScale = 0f;
        waitLevelUp = true;
    }

    public void resumeGame()
    {
        if (waitLevelUp == false)
        {
            levelupMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
           warningText.text = string.Format("Upgrade Or Unlock Spell");
           warningText.gameObject.SetActive(true);
        }
    }

    public void fireLevelUp()
    {
        if (waitLevelUp == true)
        {
            warningText.gameObject.SetActive(true);

            //Fire text
            if(fireLv != 5 && unlockedF == true)
            {
                spellControl.damageAdd(2);
                fireLv++;
                fireLvText.text = string.Format("LEVEL: " + fireLv);
                warningText.text = string.Format("Upgraded Spell! Press Continue ");
                waitLevelUp = false;
            }

            else
            {
                warningText.text = string.Format("Spell Max Level");
            }
        }
    }

    public void waterLevelUp()
    {
        if (waitLevelUp == true)
        {
            //Need to fix in all spells
            warningText.gameObject.SetActive(true);

            //Water text
            if (waterLv != 5 && unlockedW == true)
            {
                spellControl.damageAdd(1);
                waterLv++;
                waterLvText.text = string.Format("LEVEL: " + waterLv);
                warningText.text = string.Format("Upgraded Spell! Press Continue");
                waitLevelUp = false;
            }

            else if(unlockedW == false)
            {
                warningText.text = string.Format("Spell Not Yet Unlock");
            }

            else
            {
                warningText.text = string.Format("Spell Max Level");
            }
        }
    }

    public void grassLevelUp()
    {
        if (waitLevelUp == true)
        {
            //Need to fix in all spells
            warningText.gameObject.SetActive(true);

            //Water text
            if (grassLv != 5 && unlockedG == true)
            {
                spellControl.damageAdd(1);
                grassLv++;
                grassLvText.text = string.Format("LEVEL: " + grassLv);
                warningText.text = string.Format("Upgraded Spell! Press Continue");
                waitLevelUp = false;
            }

            else if (unlockedG == false)
            {
                warningText.text = string.Format("Spell Not Yet Unlock");
            }

            else
            {
                warningText.text = string.Format("Spell Max Level");

            }
        }
    }


    public void unlockWater()
    {
        if (waterScreen.activeSelf == true && waitLevelUp == true)
        {
            waterScreen.SetActive(false) ;
            warningText.text = string.Format("Unlocked New Spell! Press Continue ");
            warningText.gameObject.SetActive(true);
            waitLevelUp = false;
            unlockedW = true;

        }     
    }

    public void unlockGrass()
    {
        if (grassScreen.activeSelf == true && waitLevelUp == true)
        {
            grassScreen.SetActive(false);
            warningText.text = string.Format("Unlocked New Spell! Press Continue ");
            warningText.gameObject.SetActive(true);
            waitLevelUp = false;
            unlockedG = true;

        }
    }

    public bool sentUnlockF()
    {
        return unlockedF;
    }

    public bool sentUnlockW()
    {
        return unlockedW;
    }

    public bool sentUnlockG()
    {
        return unlockedG;
    }
}
