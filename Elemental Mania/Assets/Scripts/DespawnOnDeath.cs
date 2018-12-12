using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class DespawnOnDeath : MonoBehaviour {

    public EffectiveHealth kHealth;

    private void Start()
    {
        Assert.IsNotNull(kHealth, "Health were null for " + gameObject.name);
    }

    // Update is called once per frame
    void Update () {
        if(kHealth.CurrentHealth <= 0)
        {
            GameObject.Destroy(gameObject);
        }
	}
}
