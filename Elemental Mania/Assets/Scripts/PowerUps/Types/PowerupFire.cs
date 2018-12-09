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
    private GameObject[] kWallSlots;

    private void Awake()
    {
        kWallSlots = GameObject.FindGameObjectsWithTag("WallSlot");
        Assert.IsTrue(kWallSlots.Length > 0, "Level must contain wall slots.. Right?");
    }


    public override void Apply(GameObject player)
    {
        EffectiveHealth hp = player.GetComponent<EffectiveHealth>();
        hp.m_Resistance.Fire += 1;
        StartInferno();
    }

    void StartInferno()
    {
        // Cleanup all existing walls
        for (int i = 0; i < kWallSlots.Length; i++)
        {
            GameObject currentWallSlot = kWallSlots[i];
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
