using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Collision2D))]
public class PowerUpSpawner : MonoBehaviour {

    [SerializeField]
    private PowerUpBase[] m_PickupEffects;

    [SerializeField]
    private PowerUpBase m_CurrentPickupEffect;

    [SerializeField]
    private PowerUpBase m_ShootEffect;

    [SerializeField]
    private float kRespawnTime;

    private float TimeToRespawn;

    private SpriteRenderer m_Renderer;
    private Collider2D m_Collider;

    private void Start()
    {
        m_Renderer = GetComponent<SpriteRenderer>();
        m_Collider = GetComponent<Collider2D>();
        if(m_CurrentPickupEffect == null)
        {
            Respawn();
        }
    }

    private void Update()
    {
        if(TimeToRespawn > 0)
        {
            TimeToRespawn -= Time.deltaTime;
            // Its time to respawn
            if(TimeToRespawn <= 0)
            {
                Respawn();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PowerupController powerupController = collision.gameObject.GetComponent<PowerupController>();

        if (powerupController != null)
        {
            powerupController.Apply(m_CurrentPickupEffect);
            Expire();
        }
    }

    private void Respawn()
    {
        m_CurrentPickupEffect = m_PickupEffects[Random.Range(0, m_PickupEffects.Length - 1)];
        m_Collider.enabled = true;
        m_Renderer.enabled = true;
        m_Renderer.color = m_CurrentPickupEffect.GetColor();
    }

    private void Expire()
    {
        m_Collider.enabled = false;
        m_Renderer.enabled = false;
        TimeToRespawn = kRespawnTime;
    }

    private void OnParticleCollision(GameObject other)
    {
        PowerupController powerupController = other.GetComponentInParent<PowerupController>();

        if (powerupController != null)
        {
            powerupController.Apply(m_ShootEffect);
            Expire();
        }
    }
}
