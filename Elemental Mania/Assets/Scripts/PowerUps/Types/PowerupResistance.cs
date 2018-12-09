using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Resistance")]
public class PowerupResistance : PowerUpBase
{
    [SerializeField]
    private float kResistanceBoost;
    public override void Apply(GameObject multi)
    {
        EffectiveHealth hp = multi.GetComponent<EffectiveHealth>();
        hp.m_Resistance.Earth += kResistanceBoost;
        hp.m_Resistance.Fire += kResistanceBoost;
        hp.m_Resistance.Frost += kResistanceBoost;
        hp.m_Resistance.Wind += kResistanceBoost;
    }

    public override Color GetColor()
    {
        return Color.yellow;
    }

    public override void Remove(GameObject multi)
    {
        EffectiveHealth hp = multi.GetComponent<EffectiveHealth>();
        hp.m_Resistance.Earth -= kResistanceBoost;
        hp.m_Resistance.Fire -= kResistanceBoost;
        hp.m_Resistance.Frost -= kResistanceBoost;
        hp.m_Resistance.Wind -= kResistanceBoost;
    }
}
