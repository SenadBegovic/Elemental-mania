using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Deployable", menuName = "WallSettings")]
public class Deployable : ScriptableObject
{
    [SerializeField]
    private GameObject kWallPrefab;

    public GameObject Prefab {
        get {
            return kWallPrefab;
        }
    }

    [SerializeField]
    private int kStartingHealth;

    public int StartingHealth {
        get {
            return kStartingHealth;
        }
    }
}
