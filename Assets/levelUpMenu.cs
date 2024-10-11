using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class levelUpMenu : MonoBehaviour
{
    public GameObject levelupMenu;
    public static bool pause;
    private spellControl fire;

    void Start()
    {
        levelupMenu.SetActive(false);

        GameObject fireObject = GameObject.Find("Fire Spell LV1");
        if (fireObject != null)
        {
            fire = fireObject.GetComponent<spellControl>();
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
        fire.damage += 5;
    }
}
