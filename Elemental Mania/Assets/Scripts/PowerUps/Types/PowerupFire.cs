using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[CreateAssetMenu(menuName = "PowerUps/Fire")]
public class PowerupFire : PowerUpBase
{
    [SerializeField]
    private Deployable kDeployableSettings;

    private Color kBrown = new Color(153, 102, 51);

    public override void Apply(GameObject player)
    {
        EffectiveHealth hp = player.GetComponent<EffectiveHealth>();
        hp.m_Resistance.Fire += 1;
        StartInferno();
    }

    void StartInferno()
    {
        GameObject[]  wallSlots = GameObject.FindGameObjectsWithTag("WallSlot");

        // Cleanup all existing walls
        for (int i = 0; i < wallSlots.Length; i++)
        {
            GameObject currentWallSlot = wallSlots[i];
            for (int j = 0; j < currentWallSlot.transform.childCount; j++)
            {
                GameObject.Destroy(currentWallSlot.transform.GetChild(j).gameObject);
            }

            GameObject newWall = GameObject.Instantiate(kDeployableSettings.Prefab, currentWallSlot.transform.position, currentWallSlot.transform.rotation, currentWallSlot.transform);
            newWall.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public override Color GetColor()
    {
        return kBrown;
    }

    public override void Remove(GameObject player)
    {
        EffectiveHealth hp = player.GetComponent<EffectiveHealth>();
        hp.m_Resistance.Fire -= 1;
    }
}
