using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Speed")]
public class PowerupSpeed : PowerUpBase
{
    [SerializeField]
    private float kSpeedBonus;
    public override void Apply(GameObject obj)
    {
        PlayerController controller = PlayerLocator.instance.GetPlayerController(obj);
        if(controller != null)
            controller.kSpeed.Boost(kSpeedBonus);
    }

    public override Color GetColor()
    {
        return Color.cyan;
    }

    public override void Remove(GameObject obj)
    {
        PlayerController controller = PlayerLocator.instance.GetPlayerController(obj);
        if(controller != null)
            controller.kSpeed.SetBack(kSpeedBonus);
    }
}