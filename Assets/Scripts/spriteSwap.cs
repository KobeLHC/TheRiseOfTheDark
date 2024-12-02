using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite newSprite;

    public Timer soulCheck;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (soulCheck.getFullSoul() == true)
        {
            ChangePlayerSprite();
        }
    }

    public void ChangePlayerSprite()
    {
        if (spriteRenderer != null && newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
        }
        else
        {
            //Debug.LogWarning("SpriteRenderer or newSprite is not assigned!");
        }
    }
}
