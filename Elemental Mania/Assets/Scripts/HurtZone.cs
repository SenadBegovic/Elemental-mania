using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HurtZone : MonoBehaviour {
    [SerializeField]
    int kMaxDamage;

    private float m_NextDamageTimer;
    private Collider2D m_Trigger;

    private void Start()
    {
        m_NextDamageTimer = 0;
        m_Trigger = GetComponent<Collider2D>();
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
                // We are only interested in horizontal distance
                float distance = Mathf.Abs(collision.transform.position.x - transform.position.x);
                float range = collision.bounds.extents.x * gameObject.transform.lossyScale.x; 
                // The closer we are to the collider center, the more damage we should take
                float distanceRatio = Mathf.Clamp(1 - distance / range, 0, float.MaxValue);
                float damage = distanceRatio * kMaxDamage;
                health.TakeDamage((int)damage, ElementalType.FIRE);
            }
        }
    }
}
