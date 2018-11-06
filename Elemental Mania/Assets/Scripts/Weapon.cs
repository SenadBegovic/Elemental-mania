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

    [System.Serializable]
    struct Deployable
    {
        public GameObject Prefab;
        public int StartingHealth;
    }

    [SerializeField]
    private Deployable kDeployableSettings;

    [SerializeField]
    private int kRepairRate;

    [SerializeField]
    private int kDeployRange;

    private int kRaycastMask;

    // Use this for initialization
    protected void Start () {
        CoolingPeriod = float.MaxValue * 0.5f;
        m_Emitter = GetComponent<ParticleSystem>();
        Assert.IsTrue(m_Emitter.collision.enabled, "Must have an emitter with collisions enabled");

        kRaycastMask = LayerMask.GetMask("WallSlot");
	}
	
	// Update is called once per frame
	protected void Update () {
        CoolingPeriod += Time.deltaTime;

        if (Input.GetButtonDown(kInputMapping.kPrimaryFire))
        {
            if (CoolingPeriod > kCooldown)
            {
                CoolingPeriod = 0.0f;
                m_Emitter.Play();
            }
        }

        if(Input.GetButtonUp(kInputMapping.kPrimaryFire))
        {
            m_Emitter.Stop();
        }
	}
  
    private void FixedUpdate()
    {
        if (Input.GetButton(kInputMapping.kSecondaryFire))
        {
            RaycastHit2D raycast = Physics2D.Raycast(transform.position, transform.right, kDeployRange, kRaycastMask);
            Debug.DrawRay(transform.position, transform.right * kDeployRange);

            // We hit a deployable slot!
            if (raycast.collider != null)
            {
                Transform locationTransform = raycast.collider.transform;
                // Slot already has a wall in place, heal if same type
                if(locationTransform.childCount > 0)
                {
                    HealWall(locationTransform);
                }
                else
                {
                    SpawnWall(locationTransform);
                }

            }
        }
    }

    private void HealWall(Transform locationTransform)
    {
        // First, get the child object
        GameObject wallObject = locationTransform.GetChild(0).gameObject;
        EffectiveHealth health = wallObject.GetComponent<EffectiveHealth>();

        health.CurrentHealth += kRepairRate;
    }

    private void SpawnWall(Transform locationTransform)
    {
        GameObject newWall = GameObject.Instantiate(kDeployableSettings.Prefab, locationTransform.position, locationTransform.rotation, locationTransform);
        newWall.transform.localScale = new Vector3(1, 1, 1);
        EffectiveHealth health = newWall.GetComponent<EffectiveHealth>();
        health.CurrentHealth = kDeployableSettings.StartingHealth;
    }
}
