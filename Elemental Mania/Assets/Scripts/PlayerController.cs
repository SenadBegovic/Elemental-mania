using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float kSpeed;
    [SerializeField]
    private float kJumpForce;
    [SerializeField]
    private float kMoveInput;

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
        if (Input.GetKeyDown(KeyCode.UpArrow) && kIsGrounded)
        {
            kRb.velocity = Vector2.up * kJumpForce;
        }
	}

    private void FixedUpdate()
    {
        kIsGrounded = Physics2D.OverlapCircle(kGroundCheck.position, kCheckRadius, kGroundLayer);

        kMoveInput = Input.GetAxis("Horizontal");
        kRb.velocity = new Vector2(kMoveInput * kSpeed, kRb.velocity.y);
   }
}
