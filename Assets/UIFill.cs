using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIFIll : MonoBehaviour
{
    public int maxValue;
    public Image fill;

    private int currentValue;
 
    void Start()
    {
        currentValue = 0;
        fill.fillAmount = 0;
    }

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            add(1);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            deduct(1);
        }
    }

    public void add(int i)
    {
        currentValue += i;

        if(currentValue >= maxValue)
        {
            currentValue = maxValue;
        }

        fill.fillAmount = (float) currentValue / maxValue;
    }

    public void deduct(int i)
    {
        currentValue -= i;

        if (currentValue < 0)
        {
            currentValue = 0;
        }

        fill.fillAmount = (float)currentValue / maxValue;
    }
}
