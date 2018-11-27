using UnityEngine;

[RequireComponent(typeof(PowerMultipliers))]
public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float kSpeed;
    [SerializeField]
    private float kJumpForce;
    [SerializeField]
    private float kMoveInput;
    [SerializeField]
    private bool kFacingRight = true;

    private PowerMultipliers kPowerMultiplier;
    private Rigidbody2D kRb;
    [SerializeField]
    private Vector2 kMoveVelocity;

    private bool kIsGrounded;
    [SerializeField]
    private Transform kGroundCheck;
    [SerializeField]
    private float kCheckRadius;
    [SerializeField]
    private LayerMask kGroundLayer;

    [SerializeField]
    private InputMapping kInputMapping;

    void Start ()
    {
        kPowerMultiplier = GetComponent<PowerMultipliers>();
        kRb = GetComponent<Rigidbody2D>();
    }

	void Update ()
    {
        if (Input.GetButtonDown(kInputMapping.kVerticalMovement) && kIsGrounded)
        {
            kRb.velocity = Vector2.up * kJumpForce;
        }
	}

    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(kGroundCheck.position, kCheckRadius);
    }

    private void FixedUpdate()
    { 
        kIsGrounded = Physics2D.OverlapCircle(kGroundCheck.position, kCheckRadius, kGroundLayer);
        kMoveInput = Input.GetAxis(kInputMapping.kHorizontalMovement);
        kRb.velocity = new Vector2(kMoveInput * kSpeed * kPowerMultiplier.Movement, kRb.velocity.y);

        if(kFacingRight == false && kMoveInput > 0)
        {
            flip();
        } else if(kFacingRight == true && kMoveInput < 0)
        {
            flip();
        }
   }

    private void flip()
    {
        kFacingRight = !kFacingRight;
        transform.Rotate(Vector2.up, 180);
    }
}
