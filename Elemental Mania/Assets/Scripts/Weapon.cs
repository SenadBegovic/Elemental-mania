using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(ParticleSystem))]
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
        CoolingPeriod = float.MaxValue * 0.5f;
        m_Emitter = GetComponent<ParticleSystem>();
        Assert.IsTrue(m_Emitter.collision.enabled, "Must have an emitter with collisions enabled");        
	}
	
	// Update is called once per frame
	void Update () {
        CoolingPeriod += Time.deltaTime;

        if (Input.GetButtonDown("PlayerOne_PrimaryFire"))
        {
            if (CoolingPeriod > kCooldown)
            {
                CoolingPeriod = 0.0f;
                m_Emitter.Play();
            }
        }
	}
}
