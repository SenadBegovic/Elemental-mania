using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Ice")]
public class PowerupIce : PowerUpBase
{
    public override void Apply(GameObject player)
    {
        PlayerController claimer = player.GetComponent<PlayerController>();
        PlayerController opponent = PlayerLocator.instance.GetOpponent(claimer);

        claimer.kSpeed.Boost(0.50f);
        opponent.kSpeed.Boost(0.50f);
    }

    public override Color GetColor()
    {
        return Color.cyan;
    }

    public override void Remove(GameObject player)
    {
        PlayerController claimer = player.GetComponent<PlayerController>();
        PlayerController opponent = PlayerLocator.instance.GetOpponent(claimer);

        claimer.kSpeed.SetBack(0.50f);
        opponent.kSpeed.SetBack(0.50f);
    }
}
