using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Experimental.Rendering.Universal;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Gradient lightcolor;
    [SerializeField] private new GameObject light;

    private int days;

    public Slider nightSlider;

    public int Days => days;

    private float time = 1;
    public float reduction;
    private float reduced;

    public bool isNight;
    private bool canChangeDay = true;
    private bool canReduce;

    public delegate void onDayChanged();

    public onDayChanged dayChanged;

    public Text nightOrDay;
    public Text dayCounter;

    public GameObject[] spawnPlatformPatterns;

    private float timeBTweenSpawn;
    public float StartTimeSpawn;
    public float decreaseTime;
    public float minimumTime = 0.65f;

    public GameObject spawnedObsticle;

    public GameObject[] spawnollectionPatterns;

    private float timeBTweenSpawn2;
    public float StartTimeSpawn2;
    public float decreaseTime2;
    public float minimumTime2 = 0.65f;

    public void Start()
    {
        canReduce = true;
        reduced = 1;
        isNight = false;
        nightOrDay.text = "Day";
        Instantiate(spawnedObsticle, transform.position, Quaternion.identity);
        nightSlider.maxValue = reduction;

    }
    private void Update()
    {
        if (time > 60)
        {
            time = 0;
        }

        if ((int)time == 60 && canChangeDay)
        {
            canChangeDay = false;
            days++;
            //dayChanged();

        }

        if ((int)time == 1)
            canChangeDay = true;

        time += Time.deltaTime;
        light.GetComponent<Light2D>().color = lightcolor.Evaluate(time * 0.01657f);

        if ((int)time == 30)
        {
            isNight = true;
        }
        if ((int)time == 60)
        {
            days++;
            isNight = false;
        }

        if (isNight == true)
        {
            nightOrDay.text = "Night";
        }
        else
        {
            nightOrDay.text = "Day";
        }

        dayCounter.text = "Day " + days;

        if (timeBTweenSpawn <= 0)
        {
            int rando = UnityEngine.Random.Range(0, spawnPlatformPatterns.Length);
            Instantiate(spawnPlatformPatterns[rando], transform.position, Quaternion.identity);
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


        if (isNight)
        {
            if (timeBTweenSpawn2 <= 0)
            {
                int rando = UnityEngine.Random.Range(0, spawnollectionPatterns.Length);
                Instantiate(spawnollectionPatterns[rando], transform.position, Quaternion.identity);
                timeBTweenSpawn2 = StartTimeSpawn2;
                if (StartTimeSpawn2 > minimumTime2)
                {
                    StartTimeSpawn2 -= decreaseTime2;
                }
            }
            else
            {
                timeBTweenSpawn2 -= Time.deltaTime;

            }
        }


        if (isNight)
        {
            nightSlider.value = reduction;
 
        }         
        if( isNight && canReduce)
        {
            StartCoroutine(reduceReduction());
            canReduce = false;
        }
    }

    private IEnumerator reduceReduction()
    {
        yield return new WaitForSeconds(5);
        reduction = reduction - reduced;
        canReduce = true;
    }
}
