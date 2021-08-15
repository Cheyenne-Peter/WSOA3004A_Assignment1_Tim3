using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPointScript : MonoBehaviour
{
    public GameObject spawnedObsticle;

    void Start()
    {
        Instantiate(spawnedObsticle, transform.position, Quaternion.identity);
        
    }
}
