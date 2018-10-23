using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Resistance {
    
    [Range(0.0f, 1.0f)]
    public float Fire;

    [Range(0.0f, 1.0f)]
    public float Frost;

    [Range(0.0f, 1.0f)]
    public float Wind;

    [Range(0.0f, 1.0f)]
    public float Earth;

    public float GetResistance(ElementalType type)
    {
        switch (type)
        {
            case ElementalType.EARTH:
                return Earth;
            case ElementalType.FIRE:
                return Fire;
            case ElementalType.WIND:
                return Wind;
            case ElementalType.FROST:
                return Frost;
        }
        throw new System.Exception("Unknown elemental type");
    }
}