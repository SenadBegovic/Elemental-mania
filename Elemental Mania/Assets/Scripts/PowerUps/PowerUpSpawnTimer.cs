using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawnTimer : MonoBehaviour {
    [SerializeField]
    private PowerUpSpawnerBase kLinkedPowerup;

    private int kPropertyID;
    private Material m_Material;
    // Use this for initialization
    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        m_Material = renderer.material;

        kPropertyID = Shader.PropertyToID("_Gradient");
    }

    // Update is called once per frame
    void Update () {
        m_Material.SetFloat(kPropertyID, kLinkedPowerup.GetRespawnFractionTime);
	}
}
