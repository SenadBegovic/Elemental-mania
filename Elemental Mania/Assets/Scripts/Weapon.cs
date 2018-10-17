using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Weapon : MonoBehaviour {
    
    public int kDamage;
    public ElementalType kType;
    public int kCooldown;

    [SerializeField]
    private InputMapping kInputMapping;
    private ParticleSystem m_Emitter;
    private float CoolingPeriod;

    // Use this for initialization
    void Start () {
        m_Emitter = GetComponent<ParticleSystem>();
        Assert.IsTrue(m_Emitter.collision.enabled, "Must have an emitter with collisions enabled");        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("PlayerOne_PrimaryFire"))
        {
            CoolingPeriod += Time.deltaTime;
            if (CoolingPeriod > kCooldown)
            {
                CoolingPeriod = 0.0f;
                m_Emitter.Play();
            }
        }
	}
}
