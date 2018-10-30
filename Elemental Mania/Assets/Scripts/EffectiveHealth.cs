using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectiveHealth : MonoBehaviour {

    [SerializeField]
    private int m_Health;
    [SerializeField]
    private int kStartingHealth;
    private float m_Resistance;
    private int m_Damage;

    [SerializeField]
    private Resistance res;

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
        m_Health -= amount;
    }

    public void TakeDamage(float amount, ElementalType type)
    {
        m_Resistance = res.GetResistance(type);
        m_Damage = (int)System.Math.Round(amount -= amount * (1 - m_Resistance));
        TakeDamage(m_Damage);
    }

	void Start () {
        m_Health = kStartingHealth;
	}
}
