using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Experimental.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Gradient lightcolor;
    [SerializeField] private new GameObject light;

    private int days;

    public int Days => days;

    private float time = 1;

    public bool isNight;
    private bool canChangeDay = true;

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

    public void Start()
    {
        isNight = false;
        nightOrDay.text = "Day";
        Instantiate(spawnedObsticle, transform.position, Quaternion.identity);
    }
    private void Update()
    {
        if (time > 120)
        {
            time = 0;
        }

        if ((int)time == 120 && canChangeDay)
        {
            canChangeDay = false;
            days++;
            //dayChanged();

        }

        if ((int)time == 1)
            canChangeDay = true;

        time += Time.deltaTime;
        light.GetComponent<Light2D>().color = lightcolor.Evaluate(time * 0.008285f);

        if ((int)time == 60)
        {
            isNight = true;
        }
        if ((int)time == 120)
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
            int rando = Random.Range(0, spawnPlatformPatterns.Length);
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
    }
}
