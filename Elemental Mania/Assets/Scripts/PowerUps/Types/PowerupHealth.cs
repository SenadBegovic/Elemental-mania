using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PowerUps/Health")]
public class PowerupHealth : PowerUpBase
{
    [SerializeField]
    private int kHealthBoost;

    public override void Apply(GameObject obj)
    {
        if (PlayerLocator.instance.IsPlayer(obj))
        {
            EffectiveHealth health = obj.GetComponent<EffectiveHealth>();
            health.Heal(kHealthBoost);
        }
    }

    public override Color GetColor()
    {
        return Color.red;
    }

    public override void Remove(GameObject obj)
    {

    }
}