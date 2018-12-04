using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour {
    private int kPowerupLayer;
    [System.Serializable]
    private struct ActivePowerup
    {
        public PowerUpBase Powerup;
        public float Timeout;
    }

    [SerializeField]
    private List<ActivePowerup> m_ActivePowerups;
    private float m_CurrentTime;

    private void Start()
    {
        m_ActivePowerups = new List<ActivePowerup>();
        kPowerupLayer = LayerMask.NameToLayer("PowerUp");
        m_CurrentTime = 0;
    }

    private void Update()
    {
        m_CurrentTime += Time.deltaTime;
        CleanupPowerups();
    }

    void CleanupPowerups()
    {
        for (int i = 0; i < m_ActivePowerups.Count; i++)
        {
            m_ActivePowerups.RemoveAll((p) =>
            {
                if(p.Timeout < m_CurrentTime)
                {
                    p.Powerup.Remove(gameObject);
                    return true;
                }
                return false;
            });
        }
    }

    public void Apply(PowerUpBase powerup)
    {
        int powerUpIndex = Find(powerup);
        // If we do not have the power, we need to apply its effect and add it to the timeout queue
        if (powerUpIndex == -1)
        {
            powerup.Apply(gameObject);
            Enqueue(powerup);
        }
        else // Otherwise we need to extend its duration(without applying it)
        {
            ActivePowerup activeSlot = new ActivePowerup();
            activeSlot.Powerup = powerup;
            activeSlot.Timeout = m_CurrentTime + powerup.Duration;
            m_ActivePowerups[powerUpIndex] = activeSlot;
        }
    }

    private void Enqueue(PowerUpBase powerup)
    {
        ActivePowerup activeSlot = new ActivePowerup();
        activeSlot.Powerup = powerup;
        activeSlot.Timeout = m_CurrentTime + powerup.Duration;
        m_ActivePowerups.Add(activeSlot);
    }

    private int Find(PowerUpBase powerup)
    {
        Type currentType = powerup.GetType();
        for (int i = 0; i < m_ActivePowerups.Count; i++)
        {
            if (m_ActivePowerups[i].Powerup.GetType() == currentType)
                return i;
        }
        return -1;
    }
}
