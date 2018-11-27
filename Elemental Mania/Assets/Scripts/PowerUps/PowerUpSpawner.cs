using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {

    [SerializeField]
    private PowerUpBase m_PowerUp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PowerupController powerupController = collision.gameObject.GetComponent<PowerupController>();

        if (powerupController != null)
        {
            powerupController.Apply(m_PowerUp);
        }
    }
}
