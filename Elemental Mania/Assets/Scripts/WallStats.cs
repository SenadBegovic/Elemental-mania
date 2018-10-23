using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WallPresets")]
public class WallStats : ScriptableObject {

    [SerializeField]
    private ElementalType ktype;
    [SerializeField]
    private int kMaxHealth;
    [SerializeField]
    private Resistance kResistance;

}
