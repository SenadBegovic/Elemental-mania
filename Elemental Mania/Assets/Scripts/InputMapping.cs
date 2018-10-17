using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "InputMapping", menuName = "Input/Mapping")]
public class InputMapping : ScriptableObject {
    public string kHorizontalMovement;
    public string kVerticalMovement;
    public string kPrimaryFire;
    public string kSecondaryFire;
    public string kNextWeapon;
}
