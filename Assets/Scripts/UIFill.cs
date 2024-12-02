using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIFill : MonoBehaviour
{
    public int maxValue;
    public Image fill;
    private float timer;

    private int currentValue;
    public float stop;
 
    void Start()
    {
        currentValue = 0;
        fill.fillAmount = 0;
    }

  
    void Update()
    {
        timer += Time.deltaTime;
    }

    public void add(int i)
    {
        if(timer <= stop)
        {
           currentValue += i;
        }

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

    public float fullAmount()
    {
        return fill.fillAmount;
    }
}
