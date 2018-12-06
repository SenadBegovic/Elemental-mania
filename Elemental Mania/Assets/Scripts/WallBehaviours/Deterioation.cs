using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EffectiveHealth))]
public class Deterioation : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Damage pr second that this wall deals to itself")]
    private int kDeterioationRate = 2;
    private float m_TimeSinceLastDeterioation = 0;
    private EffectiveHealth m_Health;

    public void Start()
    {
        m_Health = GetComponent<EffectiveHealth>();
    }

    public void Update()
    {
        m_TimeSinceLastDeterioation += Time.deltaTime;
        if (m_TimeSinceLastDeterioation >= 1.0)
        {
            m_Health.TakeDamage(kDeterioationRate);
            m_TimeSinceLastDeterioation = 0;
        }
    }
}