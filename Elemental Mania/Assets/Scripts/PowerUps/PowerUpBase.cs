using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : ScriptableObject {

    [SerializeField]
    protected float kDuration;

    public float Duration
    {
        get
        {
            return kDuration;
        }
    }
    
    public abstract void Apply(PowerMultipliers multi);
    public abstract void Remove(PowerMultipliers multi);
}

[CreateAssetMenu(menuName = "PowerUps/Speed")]
public class PowerupSpeed : PowerUpBase
{
    [SerializeField]
    private float kSpeedBonus;
    public override void Apply(PowerMultipliers multi)
    {
        multi.Movement += kSpeedBonus;
    }

    public override void Remove(PowerMultipliers multi)
    {
        multi.Movement -= kSpeedBonus;
    }
}