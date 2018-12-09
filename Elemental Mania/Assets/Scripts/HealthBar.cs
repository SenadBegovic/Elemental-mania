﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Image ImgHealthBar, ImgShieldBar;
    public Text TxtHealth;
    public EffectiveHealth player;

    
    private int mCurrentValue;
    private float mCurrentPercentage;

    void Start () {
        SetHealth(player.CurrentHealth);
        
	}

    private void Update()
    {
        SetHealth(player.CurrentHealth);
    }


    public void SetHealth(int health)
    {
        if(health > player.MaxHealth)
        {
            health = player.MaxHealth;
        }

        if (health > player.MaxHealth / 2)
        {
            SetShield(health - player.MaxHealth / 2);
        }
        else
        {
            SetShield(0);
        }

        if(health != mCurrentValue)
        {
            if(player.CurrentHealth <= 0)
            {
                mCurrentValue = 0;
                mCurrentPercentage = 0;
            }
            else
            {
                mCurrentValue = health;
                mCurrentPercentage = (float)mCurrentValue / (float)(player.MaxHealth / 2);
  
            }

            TxtHealth.text = string.Format("{0} %", Mathf.RoundToInt(mCurrentPercentage  * 100));
            ImgHealthBar.fillAmount = mCurrentPercentage;
        }
    }

    public void SetShield(int health)
    {
        {
        mCurrentValue = health;
        mCurrentPercentage = (float)mCurrentValue / (float)(player.MaxHealth / 2);
        }

    ImgShieldBar.fillAmount = mCurrentPercentage;
    }

    public float CurrentPercent
    {
        get { return mCurrentPercentage; }
    }

    public int CurrentValue
    {
        get { return mCurrentValue; }
    }
}
