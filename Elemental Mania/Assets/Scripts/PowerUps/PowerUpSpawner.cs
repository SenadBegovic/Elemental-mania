using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : PowerUpSpawnerBase {
    [SerializeField]
    private PowerUpBase m_ShootEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PowerupController powerupController = collision.gameObject.GetComponent<PowerupController>();

        if (powerupController != null)
        {
            powerupController.Apply(m_CurrentEffect);
            Expire();
        }
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
