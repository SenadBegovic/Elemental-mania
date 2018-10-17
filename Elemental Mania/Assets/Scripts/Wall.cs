using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

public class Wall : MonoBehaviour {

    [SerializeField]
    WallBehaviour m_CurrentBehaviour;

    BoxCollider2D m_Collider;

    [SerializeField]
    WallBehaviour m_IdleBehaviour;

    public int Health;

	// Use this for initialization
	void Start () {
        m_Collider = GetComponent<BoxCollider2D>();

        SetBehaviour(m_CurrentBehaviour);
	}
	
    public void SetBehaviour(WallBehaviour behaviour)
    {
        if(m_CurrentBehaviour != null)
        {
            m_CurrentBehaviour.Destroy(this);
        }
        m_CurrentBehaviour = behaviour;
        m_CurrentBehaviour.Instantiate(this);
    }

	// Update is called once per frame
	void Update () {
        m_CurrentBehaviour.Tick(this);

        if(Health <= 0)
        {
            SetBehaviour(m_IdleBehaviour);
        }
	}

    private void OnParticleCollision(GameObject other)
    {
        var system = other.GetComponent<ParticleSystem>();
        int size = ParticlePhysicsExtensions.GetSafeCollisionEventSize(system);
        var events = new List<ParticleCollisionEvent>(size);
        ParticlePhysicsExtensions.GetCollisionEvents(system, gameObject, events);

        var weapon = other.GetComponent<Weapon>();
        m_CurrentBehaviour.ParticleCollision(this, weapon, events);
    }
}
