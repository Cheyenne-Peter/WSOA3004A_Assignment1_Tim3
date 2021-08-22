using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimScript : MonoBehaviour
{
    private Animator playerAnim; // accesses animator attached to player.

    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            playerAnim.SetBool("isWalking", true);// Allows the isWalking bool in animator to be called.
        }
        else 
        {
            playerAnim.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            playerAnim.SetBool("isJumping", true); // Allows "jump" trigger in  animator to be called.


        }
        else 
        {
            playerAnim.SetBool("isJumping", false);

        }
            
    }
}
