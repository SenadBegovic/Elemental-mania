using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Resistance {
    [Range(0, 100)]
    public int Fire;

    [Range(0, 100)]
    public int Frost;

    [Range(0, 100)]
    public int Wind;

    [Range(0, 100)]
    public int Earth;

    public int GetResistance(ElementalType type)
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