using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EffectiveHealth))]
public class DespawnOnDeath : MonoBehaviour {

    private EffectiveHealth kHealth;

	// Use this for initialization
	void Start () {
        kHealth = GetComponent<EffectiveHealth>();
	}
	
	// Update is called once per frame
	void Update () {
        if(kHealth.CurrentHealth <= 0)
        {
            GameObject.Destroy(gameObject);
        }
	}
}
