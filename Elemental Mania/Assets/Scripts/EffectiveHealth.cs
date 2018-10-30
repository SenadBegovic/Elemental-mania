using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    private int m_Health; 

    private WallStats k

    public void TakeDamage(int amount)
    {
        m_Health -= amount;
    }

    public void TakeDamage(int amount, ElementalType type)
    {
       // m_Health = m_Health - (amount*
    }

	void Start () {
		
	}
	
	void Update () {
		
	}
}
