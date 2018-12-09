using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HurtZone : MonoBehaviour {
    
    [SerializeField]
    private int kDamagePerSecond;

    private float m_NextDamageTimer;

    private void Start()
    {
        m_NextDamageTimer = 0;
    }

    private void FixedUpdate()
    {
        if (m_NextDamageTimer > 1.0f)
            m_NextDamageTimer = 0;
        // Calculated in FixedUpdate as OnCollisionXXX events depend on it
        m_NextDamageTimer += Time.deltaTime;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (m_NextDamageTimer > 1.0f)
        {
            EffectiveHealth health = collision.gameObject.GetComponent<EffectiveHealth>();
            if(health != null)
            {
                health.TakeDamage(kDamagePerSecond, ElementalType.FIRE);       
            }
        }
    }
}
