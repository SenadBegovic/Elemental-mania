using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectiveHealth : MonoBehaviour {

    [SerializeField]
    private int m_Health;
    [SerializeField]
    private int kStartingHealth;
    private SpriteRenderer kSpriteRenderer;

    private int m_Damage;

    [SerializeField]
    private int m_MaxHealth;

    private bool m_TookDamage;
    private float m_HurtFadeTimer;

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

    public void SetHealthPercentage(float percentage)
    {
        m_Health = (int)(m_MaxHealth * percentage);
    }

    public void TakeDamage(int amount)
    {
        int newHealth = m_Health - amount;
        m_Health = Mathf.Clamp(newHealth, 0, m_MaxHealth);
        if(m_Health > 0)
            m_TookDamage = true;
    }

    public float HealthPercentage{
        get {
            return m_Health / (float)m_MaxHealth;
        }
    }

    public int MaxHealth
    {
        get
        {
            return m_MaxHealth;
        }
    }

    public void TakeDamage(float amount, ElementalType type)
    {
        float resistance = m_Resistance.GetResistance(type);
        m_Damage = (int)System.Math.Round(amount * (1.0f - resistance));
        TakeDamage(m_Damage);
    }

    void Update()
    {
        if(m_TookDamage)
        {
            // If our hurt timer is greater then zero, then we are still in the "damaged" display state
            if(m_HurtFadeTimer > 0)
            {
                m_HurtFadeTimer -= Time.deltaTime;
                // We have waited long enough to not show hurt anymore (reset color)
                if(m_HurtFadeTimer <= 0)
                {
                    Color color = kSpriteRenderer.color;
                    color.r -= 0.5f;
                    kSpriteRenderer.color = color;
                    m_TookDamage = false;
                }
            }
            else
            {
                Color color = kSpriteRenderer.color;
                color.r += 0.5f;
                kSpriteRenderer.color = color;
                m_HurtFadeTimer = 0.5f;
            }
        }
    }

	void Start () {
        m_Health = kStartingHealth;
        m_TookDamage = false;
        kSpriteRenderer = GetComponent<SpriteRenderer>();

	}
}
