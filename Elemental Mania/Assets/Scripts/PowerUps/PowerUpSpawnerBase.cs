using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Collision2D))]
public class PowerUpSpawnerBase : MonoBehaviour
{

    [SerializeField]
    private PowerUpBase[] m_EffectsPool;

    [SerializeField]
    protected PowerUpBase m_CurrentEffect;

    private SpriteRenderer m_Renderer;
    private Collider2D m_Collider;


    [SerializeField]
    private float kRespawnTime;

    private float TimeToRespawn;

    protected void Start()
    {
        m_Renderer = GetComponent<SpriteRenderer>();
        m_Collider = GetComponent<Collider2D>();
        if (m_CurrentEffect == null)
        {
            Respawn();
        }
        else
        {
            Display();
        }
    }



    protected void Update()
    {
        if (TimeToRespawn > 0)
        {
            TimeToRespawn -= Time.deltaTime;
            // Its time to respawn
            if (TimeToRespawn <= 0)
            {
                Respawn();
            }
        }
    }

    protected virtual void Respawn()
    {
        m_CurrentEffect = m_EffectsPool[Random.Range(0, m_EffectsPool.Length - 1)];
        Display();
    }

    protected virtual void Display()
    {
        m_Collider.enabled = true;
        m_Renderer.enabled = true;
        m_Renderer.sprite = m_CurrentEffect.kSprite;
    }

    protected virtual void Expire()
    {
        m_Collider.enabled = false;
        m_Renderer.enabled = false;
        TimeToRespawn = kRespawnTime;
    }

}
