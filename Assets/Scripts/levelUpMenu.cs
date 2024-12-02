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

    public GameObject pauseMenu;

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

    public Timer maxLevel;
    public bool updateOnce;
    public playerXP showOnce;

    //Audio
    audioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>();
    }

    void Start()
    {
        levelupMenu.SetActive(false);
        pauseMenu.SetActive(false);
        waterScreen.SetActive(true);
        grassScreen.SetActive(true);
        unlockedF = true;
        unlockedW = false;
        unlockedG = false;
        updateOnce = false;

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
        if (maxLevel.getFullSoul() == true && updateOnce == false)
        {
            fireLv = 5;
            waterLv = 5;
            grassLv = 5;
            updateOnce = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            audioManager.playSFX(audioManager.pause);
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
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

        if(showOnce.getShowOnce() == true)
        {
            unlockWater();
            unlockGrass();
            warningText.text = string.Format("All Spell Max Level! Press Continue");
            warningText.gameObject.SetActive(true);

            //Add base dmg after final big upgrade
            spellControl.allMax();
        }
    }

    public void resumeGame()
    {
        if (waitLevelUp == false)
        {
            audioManager.playSFX(audioManager.buttons);
            levelupMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        else
        {
           audioManager.playSFX(audioManager.buttons);
           warningText.text = string.Format("Upgrade Or Unlock Spell");
           warningText.gameObject.SetActive(true);
        }
    }

    public void backMain()
    {
        audioManager.playSFX(audioManager.buttons);
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void pauseResume()
    {
        audioManager.playSFX(audioManager.pause);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void fireLevelUp()
    {
        if (waitLevelUp == true && showOnce.getShowOnce() != true)
        {
            warningText.gameObject.SetActive(true);

            //Fire text
            if(fireLv != 5 && unlockedF == true)
            {
                audioManager.playSFX(audioManager.upgrade);
                spellControl.damageAddFire(2);
                fireLv++;
                fireLvText.text = string.Format("LEVEL: " + fireLv);
                warningText.text = string.Format("Upgraded Spell! Press Continue ");
                waitLevelUp = false;
            }

            else
            {
                audioManager.playSFX(audioManager.buttons);
                warningText.text = string.Format("Spell Max Level");
            }
        }
    }

    public void waterLevelUp()
    {
        if (waitLevelUp == true && showOnce.getShowOnce() != true)
        {
            //Need to fix in all spells
            warningText.gameObject.SetActive(true);

            //Water text
            if (waterLv != 5 && unlockedW == true)
            {
                audioManager.playSFX(audioManager.upgrade);
                spellControl.damageAddWater(1);
                waterLv++;
                waterLvText.text = string.Format("LEVEL: " + waterLv);
                warningText.text = string.Format("Upgraded Spell! Press Continue");
                waitLevelUp = false;
            }

            else if(unlockedW == false)
            {
                audioManager.playSFX(audioManager.buttons);
                warningText.text = string.Format("Spell Not Yet Unlock");
            }

            else
            {
                audioManager.playSFX(audioManager.buttons);
                warningText.text = string.Format("Spell Max Level");
            }
        }
    }

    public void grassLevelUp()
    {
        if (waitLevelUp == true && showOnce.getShowOnce() != true)
        {
            warningText.gameObject.SetActive(true);

            //grass text
            if (grassLv != 5 && unlockedG == true)
            {
                audioManager.playSFX(audioManager.upgrade);
                //spellControl.damageAdd(1);
                grassLv++;
                grassLvText.text = string.Format("LEVEL: " + grassLv);
                warningText.text = string.Format("Upgraded Spell! Press Continue");
                waitLevelUp = false;
            }

            else if (unlockedG == false)
            {
                audioManager.playSFX(audioManager.buttons);
                warningText.text = string.Format("Spell Not Yet Unlock");
            }

            else
            {
                audioManager.playSFX(audioManager.buttons);
                warningText.text = string.Format("Spell Max Level");

            }
        }
    }

    public void unlockWater()
    {
        if (waterScreen.activeSelf == true && waitLevelUp == true && showOnce.getShowOnce() != true)
        {
            audioManager.playSFX(audioManager.upgrade);
            waterScreen.SetActive(false);
            warningText.text = string.Format("Unlocked New Spell! Press Continue ");
            warningText.gameObject.SetActive(true);
            waitLevelUp = false;
            unlockedW = true;

        }    
        
        else if(showOnce.getShowOnce() == true)
        {
            waterScreen.SetActive(false);
            waitLevelUp = false;
            unlockedW = true;
        }
    }

    public void unlockGrass()
    {
        if (grassScreen.activeSelf == true && waitLevelUp == true && showOnce.getShowOnce() != true)
        {
            audioManager.playSFX(audioManager.upgrade);
            grassScreen.SetActive(false);
            warningText.text = string.Format("Unlocked New Spell! Press Continue ");
            warningText.gameObject.SetActive(true);
            waitLevelUp = false;
            unlockedG = true;

        }

        else if (showOnce.getShowOnce() == true)
        {
            grassScreen.SetActive(false);
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

    public int sentGrassCoolDown()
    {
        return grassLv;
    }

    public int sentFireLv()
    {
        return fireLv;
    }

    public int sentWaterLv()
    {
        return waterLv;
    }
}
