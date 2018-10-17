using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = kTypeName, menuName = WallBehaviour.kWallFolder + kTypeName)]
public class EarthWallBehaviour : WallBehaviour
{
    public const string kTypeName = "Earth Wall";

    public override void Tick(Wall _this)
    {

    }
}
