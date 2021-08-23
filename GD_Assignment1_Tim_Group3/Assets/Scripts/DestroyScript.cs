using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyScript : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "platform") 
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

        if (collision.gameObject.tag == "collectable")
        {
            Destroy(collision.gameObject);
        }

    }

}
