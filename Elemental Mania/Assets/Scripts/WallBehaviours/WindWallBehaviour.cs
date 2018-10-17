using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = kTypeName, menuName = WallBehaviour.kWallFolder + kTypeName)]
public class WindWallBehaviour : WallBehaviour {
    public const string kTypeName = "WindWall";

    public override void Tick(Wall _this)
    {
    }
}
