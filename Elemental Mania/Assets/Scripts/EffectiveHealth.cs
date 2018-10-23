using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectiveHealth : MonoBehaviour {

    [SerializeField]
    private int m_Health; 

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

    public void TakeDamage(int amount, ElementalType type)
    {
        TakeDamage(amount);
    }

	void Start () {
		
	}
	
	void Update () {
		
	}
}
