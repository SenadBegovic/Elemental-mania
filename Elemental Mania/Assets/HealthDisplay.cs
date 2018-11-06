using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HealthDisplay : MonoBehaviour {

    [SerializeField]
    private EffectiveHealth m_TargetHealth;

    private int kPropertyID;
    private Material m_Material;
	// Use this for initialization
	void Start () {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        m_Material = renderer.material;
        kPropertyID = Shader.PropertyToID("_Gradient");
	}
	
	// Update is called once per frame
	void Update () {
        float health = m_TargetHealth.HealthPercentage;
        m_Material.SetFloat(kPropertyID, health);
    }
}
