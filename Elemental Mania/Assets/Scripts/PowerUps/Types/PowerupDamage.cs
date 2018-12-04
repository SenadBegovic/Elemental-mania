using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Damage")]
public class PowerupDamage : PowerUpBase
{
    [SerializeField]
    private float kDamageBoost;
    public override void Apply(GameObject player)
    {
        WeaponController controller = player.GetComponent<WeaponController>();
        if(controller != null)
        {
            Weapon[] weapons = controller.Weapons;
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].Damage.Boost(kDamageBoost);
            }
        }
    }

    public override Color GetColor()
    {
        throw new System.NotImplementedException();
    }

    public override void Remove(GameObject player)
    {
        WeaponController controller = player.GetComponent<WeaponController>();
        if (controller != null)
        {
            Weapon[] weapons = controller.Weapons;
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].Damage.SetBack(kDamageBoost);
            }
        }
    }
}
