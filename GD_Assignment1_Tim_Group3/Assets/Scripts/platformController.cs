using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformController : MonoBehaviour
{
    private Rigidbody2D rBody;

    public float speed; // Dictates the speed the platforms will travel at.
   


    private void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
       
        rBody.velocity = new Vector2(0f, speed);
      
    }
}
