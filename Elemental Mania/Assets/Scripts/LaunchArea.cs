using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchArea : MonoBehaviour {

    [SerializeField]
    private int kForce;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerLocator.instance.IsPlayer(collision.gameObject))
        {
            GameObject player = PlayerLocator.instance.GetPlayer(collision.gameObject);
            Rigidbody2D rigidBody = player.GetComponent<Rigidbody2D>();

            Vector2 velocity = rigidBody.velocity;

            Debug.Log(player.name);
            // Player is moving to the right
            if (velocity.x > 0)
            {
                rigidBody.AddForce(Vector2.right * kForce, ForceMode2D.Impulse);
            }
            else // Player is moving to the left
            {
                rigidBody.AddForce(Vector2.left * kForce, ForceMode2D.Impulse);
            }
        }
    }
}
