using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Deterioation : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Damage pr second that this wall deals to itself")]
    private int kDeterioationRate = 2;
    private float m_TimeSinceLastDeterioation = 0;
    private Health m_Health;  


    public void Update()
    {
        m_TimeSinceLastDeterioation += Time.deltaTime;
        if (m_TimeSinceLastDeterioation <= 0.5)
        {
            m_Health -= kDeterioationRate;
        }
    }
}
