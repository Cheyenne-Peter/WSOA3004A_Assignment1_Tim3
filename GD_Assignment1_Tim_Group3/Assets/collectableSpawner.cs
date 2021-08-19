using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableSpawner : MonoBehaviour
{
    public GameObject[] spawnollectionPatterns;

    private float timeBTweenSpawn;
    public float StartTimeSpawn;
    public float decreaseTime;
    public float minimumTime = 0.65f;

    // Update is called once per frame
    void Update()
    {
        if (timeBTweenSpawn <= 0)
        {
            int rando = Random.Range(0, spawnollectionPatterns.Length);
            Instantiate(spawnollectionPatterns[rando], transform.position, Quaternion.identity);
            timeBTweenSpawn = StartTimeSpawn;
            if (StartTimeSpawn > minimumTime)
            {
                StartTimeSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBTweenSpawn -= Time.deltaTime;

        }



    }
}
