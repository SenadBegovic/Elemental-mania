using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtZone : MonoBehaviour {
    public int DamagePerSecond;

    private void OnCollisionStay2D(Collision2D collision)
    {
        int damageToDeal = (int)(Time.deltaTime * DamagePerSecond);

        // TODO: Get player and deal damage
    }
}
