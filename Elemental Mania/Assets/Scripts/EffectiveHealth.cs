using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectiveHealth : MonoBehaviour {

    [SerializeField]
    private int m_Health;
    [SerializeField]
    private int kStartingHealth;
    private int m_Damage;

    [SerializeField]
    private int m_MaxHealth;

    [SerializeField]
    public Resistance m_Resistance;

    public int CurrentHealth{
        get{
            return m_Health;
        }

        set{
            m_Health = value;
        }
    }

    public void TakeDamage(int amount)
    {
        int newHealth = m_Health - amount;
        m_Health = Mathf.Clamp(newHealth, 0, m_MaxHealth);
    }

    public float HealthPercentage{
        get {
            return m_Health / (float)m_MaxHealth;
        }
    }

    public void TakeDamage(float amount, ElementalType type)
    {
        float resistance = m_Resistance.GetResistance(type);
        m_Damage = (int)System.Math.Round(amount * (1.0f - resistance));
        TakeDamage(m_Damage);
    }

	void Start () {
        m_Health = kStartingHealth;
	}
}
