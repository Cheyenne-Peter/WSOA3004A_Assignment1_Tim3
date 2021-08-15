using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colletableSpawnPointScript : MonoBehaviour
{
    public GameObject spawnedCollectable;
    // Start is called before the first frame update
    void Start()
    {

        Instantiate(spawnedCollectable, transform.position, Quaternion.identity);
    }

   
}
