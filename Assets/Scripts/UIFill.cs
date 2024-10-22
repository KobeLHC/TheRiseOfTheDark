using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIFill : MonoBehaviour
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

    public bool isFull()
    {
        if(currentValue == maxValue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
