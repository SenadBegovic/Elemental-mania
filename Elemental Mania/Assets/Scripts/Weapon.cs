using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(ParticleSystem))]
public class Weapon : MonoBehaviour {
    public BoostableValue Damage;
    public ElementalType kType;
    public int kCooldown;

    [SerializeField]
    private InputMapping kInputMapping;
    private ParticleSystem m_Emitter;
    private float CoolingPeriod;
    private WeaponController weapon;

    [SerializeField]
    private Deployable kDeployableSettings;

    [SerializeField]
    private int kRepairRate;

    [SerializeField]
    private int kDeployRange;

    private int kRaycastMask;

    // We use the rigidbody, to figure out how fast the player is moving
    // Then we use the cached field kEmissionVelocity to figure out how 
    // fast the particle system must move in relation to the player
    // NOTE: This is a copy of the initial emission velocity set on the particle system
    private Rigidbody2D kRigidBody;
    private float kEmissionVelocity;

    // Use this for initialization
    protected void Start () {
        CoolingPeriod = kCooldown;
        m_Emitter = GetComponent<ParticleSystem>(); 
        Assert.IsTrue(m_Emitter.collision.enabled, "Must have an emitter with collisions enabled");

        kRaycastMask = LayerMask.GetMask("WallSlot");
        kRigidBody = GetComponentInParent<Rigidbody2D>();

        kEmissionVelocity = m_Emitter.main.startSpeed.constant;
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

        // Update emission velocity to prevent walking into own fire
      
        ParticleSystem.MainModule main = m_Emitter.main;
        main.startSpeed = Mathf.Abs(kRigidBody.velocity.x) + kEmissionVelocity;

        if (Input.GetButtonUp(kInputMapping.kPrimaryFire))
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
                if(locationTransform.childCount == 0)
                {
                    SpawnWall(locationTransform);
                }

            }
        }
    }

    private void OnEnable()
    {
        CoolingPeriod = kCooldown;
    }

    private void HealWall(Transform locationTransform)
    {
        // First, get the child object
        GameObject wallObject = locationTransform.gameObject;
        EffectiveHealth health = wallObject.GetComponent<EffectiveHealth>();

        health.CurrentHealth += kRepairRate;
    }

    private void SpawnWall(Transform locationTransform)
    {
        GameObject newWall = GameObject.Instantiate(kDeployableSettings.Prefab, locationTransform.position, locationTransform.rotation, locationTransform);
        newWall.transform.localScale = new Vector3(1, 1, 1);
    }
}
