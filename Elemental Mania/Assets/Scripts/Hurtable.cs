using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[RequireComponent(typeof(EffectiveHealth), typeof(Collision2D))]
public class Hurtable : MonoBehaviour {

    private EffectiveHealth kHealth;

    private List<ParticleCollisionEvent> m_CollisionEventBuffer;
	// Use this for initialization
	void Start () {
        kHealth = GetComponent<EffectiveHealth>();
        m_CollisionEventBuffer = new List<ParticleCollisionEvent>();
	}

    private void OnParticleCollision(GameObject other)
    {
        var system = other.GetComponent<ParticleSystem>();
        var weapon = other.GetComponent<Weapon>();

        int hitCount = ParticlePhysicsExtensions.GetSafeCollisionEventSize(system);
        ParticlePhysicsExtensions.GetCollisionEvents(system, gameObject, m_CollisionEventBuffer);

        kHealth.TakeDamage(weapon.kBaseDamage * hitCount, weapon.kType);
    }
}
