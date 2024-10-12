using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelUpMenu : MonoBehaviour
{
    public GameObject levelupMenu;
    public static bool pause;
    public spellControl fire;

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
    }

    void Update()
    {
        
    }


    public void pauseGame()
    {
        levelupMenu.SetActive(true);
        Time.timeScale = 0f;
        pause = true;
    }

    public void resumeGame()
    {
        levelupMenu.SetActive(false);
        Time.timeScale = 1f;
        pause = false;
    }

    public void levelUp()
    {
        spellControl.damageAdd(5);
        levelupMenu.SetActive(false);
        Time.timeScale = 1f;
        pause = false;

    }
}
