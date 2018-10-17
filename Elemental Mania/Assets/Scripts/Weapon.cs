using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Weapon : MonoBehaviour {

    public int Damage;
    public ElementalType type;
    public int Cooldown;

    private ParticleSystem m_Emitter;


	// Use this for initialization
	void Start () {
        m_Emitter = GetComponent<ParticleSystem>();
        Assert.IsTrue(m_Emitter.collision.enabled, "Must have an emitter with collisions enabled");        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("PrimaryFire"))
        {
            if(Time.deltaTime > 1.0f)
            {
                m_Emitter.Play();
            }
        }
	}
}
