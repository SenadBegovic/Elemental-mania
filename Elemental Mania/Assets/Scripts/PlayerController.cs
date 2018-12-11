using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    public BoostableValue kSpeed;
    [SerializeField]
    private float kJumpForce;
    [SerializeField]
    private float kMoveInput;
    [SerializeField]
    private bool kFacingRight = true;
    
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
        Vector2 currentVelocity = kRb.velocity;
        float currentSpeed = Mathf.Abs(currentVelocity.x);
        if(currentSpeed <= kSpeed.value)
        {
            if (kMoveInput != 0)
                kRb.velocity = new Vector2(kMoveInput * kSpeed.value, kRb.velocity.y);
        }
        else
        {
            Vector2 breakPower = new Vector2(kMoveInput * kSpeed.value, 0);
            Vector2 currentHorizontalVelocity = new Vector2(currentVelocity.x, 0);
            float newVelocity = GetEstimatedVelocity(breakPower, currentHorizontalVelocity);

            if(newVelocity < currentHorizontalVelocity.magnitude)
            {
                kRb.AddForce(breakPower);
            }
        }

        if (kFacingRight == false && kMoveInput > 0)
        {
            Flip();
        } else if(kFacingRight == true && kMoveInput < 0)
        {
            Flip();
        }
   }

    float GetEstimatedVelocity(Vector2 force, Vector2 currentVelocity)
    {
        return (force.magnitude / kRb.mass)*Time.fixedDeltaTime + currentVelocity.magnitude;
    }

    private void Flip()
    {
        kFacingRight = !kFacingRight;
        transform.Rotate(Vector2.up, 180);
    }
}
