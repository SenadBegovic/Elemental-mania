using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[RequireComponent(typeof(EffectiveHealth), typeof(Collision2D))]
public class Hurtable : MonoBehaviour {

    private EffectiveHealth kHealth;

    private List<ParticleCollisionEvent> m_CollisionEventBuffer;
    /// <summary>
    /// Used for knockback effect from wind type - might be null
    /// </summary>
    private Rigidbody2D kRigidBody;
	// Use this for initialization
	void Start () {
        kHealth = GetComponent<EffectiveHealth>();
        m_CollisionEventBuffer = new List<ParticleCollisionEvent>();
        kRigidBody = GetComponent<Rigidbody2D>();
	}

    private void OnParticleCollision(GameObject other)
    {
        var system = other.GetComponent<ParticleSystem>();
        var weapon = other.GetComponent<Weapon>();

        int hitCount = ParticlePhysicsExtensions.GetSafeCollisionEventSize(system);
        ParticlePhysicsExtensions.GetCollisionEvents(system, gameObject, m_CollisionEventBuffer);

        kHealth.TakeDamage(weapon.Damage.value * hitCount, weapon.kType);
        if(weapon.kType == ElementalType.WIND && kRigidBody != null)
        {
            Debug.DrawRay(transform.position, transform.position - other.transform.position, Color.green, 5);
            Vector3 directionPosition = transform.position + new Vector3(0, 0.25f, 0);
            Vector3 direction = (directionPosition - other.transform.position);
            Vector2 realDirection = new Vector2(direction.x, direction.y);
            Vector2 breakVector = new Vector2(-kRigidBody.velocity.x, 0);
            kRigidBody.AddForce(breakVector + realDirection.normalized * 5, ForceMode2D.Impulse);
        }
    }
}
