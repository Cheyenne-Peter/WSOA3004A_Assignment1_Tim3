using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyScript : MonoBehaviour
{

    void Update()
    {
       
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "platform") 
        {
            Destroy(collision.gameObject);
            collision.transform.parent = null;
        }

        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

    }

}
