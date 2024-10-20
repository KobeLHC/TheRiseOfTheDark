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
    public spellControl fire;

    public TextMeshProUGUI warningText;

    void Start()
    {
        levelupMenu.SetActive(false);

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
        levelupMenu.SetActive(true);
        warningText.gameObject.SetActive(false);
        Time.timeScale = 0f;
        waitLevelUp = true;
    }

    public void resumeGame()
    {
        if(waitLevelUp == false)
        {
            levelupMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            warningText.gameObject.SetActive(true);
        }
    }

    public void levelUp()
    {
        if (waitLevelUp == true)
        {
            spellControl.damageAdd(5);
            levelupMenu.SetActive(false);
            Time.timeScale = 1f;
            waitLevelUp = false;
        }
    }
}
