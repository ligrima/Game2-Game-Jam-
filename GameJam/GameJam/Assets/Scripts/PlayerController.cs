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

    // This is the character's animator
    Animator anim;

    // This is the character's physics component
    Rigidbody2D playerRB;

    // This is the character's amount of lives
    public int playerLives = 5;

    // This is the canvas text box
    public Text lifeText;

    // This is the character's sprite rendered
    SpriteRenderer spriteRenderer;

    // The ground checking object
    Transform groundCheck;

    // Is the player touching the ground?
    bool isGrounded = true;

    // The player's default position
    Vector3 defaultPos;

    // When the script is activated, get its components
    void Awake()
    {
        anim = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        groundCheck = transform.Find("groundCheck");
        defaultPos = transform.position;
    }

    // Since we are using physics, use the FixedUpdate method
    void FixedUpdate()
    {
        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        anim.SetBool("isGrounded", isGrounded);

        //this tackles the left and right arrow keys
        float h = Input.GetAxisRaw("Horizontal");

        //jump to the move method
        Move(h);

        // make the character jump!
        if (Input.GetButtonDown("Jump") && isGrounded)
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
            if (playerLives > 1 )
            {
                playerLives --;

                // adjust the life on the canvas
                lifeText.text = "Lives: " + playerLives;

                // Show us the score in the console
                Debug.Log(playerLives);
                
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

        //check that the player is looking in the direction he's moving
        if ((h < 0f && !spriteRenderer.flipX) || (h > 0f && spriteRenderer.flipX))
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        //if h is zero, character is still
        // if h is not zero, character is moving
        bool isWalking = (h != 0f);

        //set the boolean value to the condition above
        anim.SetBool("isWalking", isWalking);
    }
  }
