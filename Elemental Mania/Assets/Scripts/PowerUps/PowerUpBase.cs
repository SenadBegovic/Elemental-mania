using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BoostableValue
{
    public void Boost(float amount)
    {
        m_Multiplier += amount;
    }

    public void SetBack(float amount)
    {
        m_Multiplier -= amount;
    }

    [SerializeField]
    private float m_Multiplier;
    [SerializeField]
    private float m_BaseValue;
    public float value
    {
        get
        {
            return m_BaseValue * m_Multiplier;
        }
    }
}

public abstract class PowerUpBase : ScriptableObject {

    [SerializeField]
    protected float kDuration;

    [SerializeField]
    public Sprite kSprite;

    public float Duration
    {
        get
        {
            return kDuration;
        }
    }

    public abstract Color GetColor();
    public abstract void Apply(GameObject player);
    public abstract void Remove(GameObject player);
}


