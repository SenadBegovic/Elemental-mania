using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EffectiveHealth))]
public class PowerUpDestructableSpawner : PowerUpSpawnerBase
{
    private EffectiveHealth kHealth;

    private GameObject m_LastDamageCommitter;
    private bool m_Died;

    // Use this for initialization
    new void Start () {
        kHealth = GetComponent<EffectiveHealth>();
        base.Start();
	}

    protected override void Respawn()
    {
        base.Respawn();
        kHealth.SetHealthPercentage(1.0f);
        m_Died = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        m_LastDamageCommitter = other;
    }

    // Update is called once per frame
    new void Update () {
        if(kHealth.CurrentHealth <= 0 && !m_Died)
        {
            if(m_LastDamageCommitter != null)
            {
                PowerupController controller = m_LastDamageCommitter.GetComponentInParent<PowerupController>();
                if(controller != null)
                    controller.Apply(m_CurrentEffect);
                m_LastDamageCommitter = null;
            }
            Expire();
            m_Died = true;
        }
        base.Update();
	}
}
