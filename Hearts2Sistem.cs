﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Hearts2Sistem : MonoBehaviour
{
    private int maxHeartAmount = 5;
    public int startHearts = 1;
    public int curHealth;
    private int maxHealth;
    private int healthPerHeart = 2;

    public Image[] healthImages;
    public Sprite[] healthSprites;

    

    // Use this for initialization
    void Start()
    {
        curHealth = startHearts * healthPerHeart;
        maxHealth = maxHeartAmount * healthPerHeart;
        checkHealthAmount();
    }


    
    void checkHealthAmount()
    {
        for (int i = 0; i < maxHeartAmount; i++)
        {
            if (startHearts <= i)
            { healthImages[i].enabled = false; }
            else
            { healthImages[i].enabled = true; }
        }
        UpdateHearts();
    }

    void UpdateHearts()
    {
        bool empty = false;
        int i = 0;

        foreach (Image image in healthImages)
        {
            if (empty)
            {
                image.sprite = healthSprites[0];
            }
            else
            {
                i++;

                if (curHealth >= i * healthPerHeart)
                { image.sprite = healthSprites[healthSprites.Length - 1]; }
                else
                {
                    int currentHeartHealth = (int)(healthPerHeart - (healthPerHeart * i - curHealth));
                    int healthPerImage = healthPerHeart / (healthSprites.Length - 1);
                    int imageIndex = currentHeartHealth / healthPerImage;
                    image.sprite = healthSprites[imageIndex];
                    empty = true;
                }
            }
        }

    }
public void TakeDamage(int amount)
{
        curHealth += amount;
        curHealth = Mathf.Clamp(curHealth, 0, startHearts * healthPerHeart);
        UpdateHearts();
    }

    public void AddHeartContainer()
    { startHearts++;
        startHearts = Mathf.Clamp(startHearts, 0, maxHeartAmount);

        curHealth = startHearts * healthPerHeart;
        maxHealth = maxHeartAmount * healthPerHeart;
        checkHealthAmount();
    }

}


