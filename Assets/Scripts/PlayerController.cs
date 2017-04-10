using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // the character's speed
    float speed = 5f;

    // the character's jump force
    float jumpForce = 300f;

    // this is the character's physiscs component
    Rigidbody2D playerRB;

    // the ground checking object
    Transform groundCheck;

    // is the player touching the ground?
    bool isGrounded = true;

    // the player's default position
    Vector3 defaultPos;

    // when the script is activated, get its components
    void Awake () {

        playerRB = GetComponent<Rigidbody2D>();

        groundCheck = transform.Find("groundCheck");
        defaultPos = transform.position;

    }

    // since we're using physics, use the FixedUpdate method
    void FixedUpdate()
    {        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        // this tackles the left and right arrow keys
        float h = Input.GetAxisRaw("Horizontal");

        // jump to the Move method
        Move(h);

        // make the character jump!
        if (Input.GetButtonDown("Jump"))
        {            playerRB.AddForce(Vector2.up * jumpForce);        }    }

    // when the player disappears, resst him
    void OnBecameInvisible()
    {
        transform.position = defaultPos;
        transform.rotation = Quaternion.identity;
    }

    // we can use this to move the character
    void Move (float h) {

        // refer to the current physics movement
        Vector2 movement = playerRB.velocity;
        movement.x = h * speed;

        // make the charcater move
        playerRB.velocity = movement;

    }
}
