using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EffectiveHealth))]
public class PowerUpDestructableSpawner : PowerUpSpawnerBase
{
    private EffectiveHealth kHealth;

    private GameObject m_LastDamageCommitter;

    // Use this for initialization
    new void Start () {
        kHealth = GetComponent<EffectiveHealth>();
        base.Start();
	}

    protected override void Respawn()
    {
        base.Respawn();
        kHealth.SetHealthPercentage(1);
    }

    private void OnParticleCollision(GameObject other)
    {
        m_LastDamageCommitter = other;
    }

    // Update is called once per frame
    new void Update () {
        if(kHealth.CurrentHealth <= 0)
        {
            if(m_LastDamageCommitter != null)
            {
                PowerupController controller = m_LastDamageCommitter.GetComponentInParent<PowerupController>();
                if(controller != null)
                    controller.Apply(m_CurrentEffect);
                m_LastDamageCommitter = null;
            }
            Expire();
        }
        base.Update();
	}
}
