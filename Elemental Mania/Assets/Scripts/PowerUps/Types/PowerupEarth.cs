using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Earth")]
public class PowerupEarth : PowerUpBase
{
    [SerializeField]
    private int m_OverHeal;

    private Color kBrown = new Color(153, 102, 51);

    public override void Apply(GameObject player)
    {
        PlayerController claimer = player.GetComponent<PlayerController>();
        EffectiveHealth hp = claimer.GetComponent<EffectiveHealth>();
        hp.CurrentHealth += m_OverHeal;
    }

    public override Color GetColor()
    {
        return kBrown;
    }

    public override void Remove(GameObject player)
    {   
        // Do nothing
    }
}
