using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    // The character's speed
    float speed = 5f;

    // The character's jump force
    float jumpForce = 300f;

    // This is the character's physics component
    Rigidbody2D playerRB;

    // This is the character's amount of lives
    public int playerLives = 4;

    // The ground checking object
    Transform groundCheck;

    // Is the player touching the ground?
    bool isGrounded = true;

    // The player's default position
    Vector3 defaultPos;

    // When the script is activated, get its components
    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();

        groundCheck = transform.Find("groundCheck");
        defaultPos = transform.position;
    }

    // Since we are using physics, use the FixedUpdate method
    void FixedUpdate()
    {
        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        
        //this tackles the left and right arrow keys
        float h = Input.GetAxisRaw("Horizontal");

        //jump to the move method
        Move(h);

        // make the character jump!
        if (Input.GetButtonDown("Jump"))
        {
            playerRB.AddForce(Vector2.up * jumpForce);
        }
    }

    // When the player disappears, reset him
    private void OnBecameInvisible()
    {
        //check if position of the character is less than 0 on the Y axis
        if (transform.position.y < 0)
        {

        //if the amount of lives is greater than 0, decrease lives by 1
            if (playerLives > 0 )
            {
                playerLives --;
           }
       //else, die and game over
                else
            {
                //gameover
                SceneManager.LoadScene("GameOver Scene");
            }
        }
        transform.position = defaultPos;
        transform.rotation = Quaternion.identity;
    }

    // We can use this to move the character
    void Move (float h)
    {
        // Refer to the current physics movement
        Vector2 movement = playerRB.velocity;
        movement.x = h * speed;

        // Make the character move
        playerRB.velocity = movement;

        

    }
}
