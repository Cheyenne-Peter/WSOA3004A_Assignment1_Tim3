using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
=======
using UnityEngine.UI;
>>>>>>> main

public class playerControllerScript : MonoBehaviour
{
    public float movementSpeed; // movement speed of player character.
    public float jumpForce;    // applied force when player character jumps.

    public Rigidbody2D rBody;

    float movementX; // movement on x-axsis.

    public bool isGrounded; //Bool to check if player is on the ground.
   
    public LayerMask groundLayer;

    private Collider2D playerCollider; // Accesses the collider attached to the player object.

<<<<<<< HEAD
=======
    public GameManager gMan;

    public int score;
>>>>>>> main
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>(); 
        playerCollider = GetComponent<Collider2D>();
    }


    void Update()
    {
        isGrounded = Physics2D.IsTouchingLayers(playerCollider, groundLayer); //isGrounded Bool checks if the player box collider is touching a collider with a  ground layer.

        movementX = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space)) // facilitates jump when spcaebar is pressed
        {
            if (isGrounded) 
            {
                rBody.velocity = new Vector2(rBody.velocity.x, jumpForce);
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(movementX * movementSpeed, rBody.velocity.y);

        rBody.velocity = movement;
    }
<<<<<<< HEAD
=======

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "collectable")
        {
            score++;
            Debug.Log("New Thing!");
            gMan.reduction++;
        }
    }
>>>>>>> main
}
