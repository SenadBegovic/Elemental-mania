using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Wind")]
public class PowerupWind : PowerUpBase
{
    public override void Apply(GameObject player)
    {
        PlayerController claimer = player.GetComponent<PlayerController>();
      

    }

    public override Color GetColor()
    {
        return Color.gray;
    }

    public override void Remove(GameObject player)
    {
       
    }
}
