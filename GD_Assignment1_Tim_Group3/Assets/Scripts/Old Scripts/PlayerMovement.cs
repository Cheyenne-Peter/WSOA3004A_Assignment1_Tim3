using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D playerRB;
    public float movespeed;

    public int score;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        float HorizontalMovement = Input.GetAxisRaw("Horizontal");
        playerRB.velocity = new Vector2(HorizontalMovement * movespeed, playerRB.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "collectable")
        {
            score++;
            Debug.Log("New Thing!");
        }
    }

}
