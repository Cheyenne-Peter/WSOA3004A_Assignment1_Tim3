using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

    //public Text nightOrDay;
    public Text dayCounter;

    /// <summary>
    /// Spawning all the different platforms
    /// </summary>
    public GameObject[] spawnPlatformPatterns;
    public GameObject[] spawnPlatformPatterns2;
    // public GameObject spawnedObsticle;

    private float timeBTweenSpawn;
    public float StartTimeSpawn;
    public float decreaseTime;
    public float minimumTime = 0.65f;


    /// <summary>
    /// Spawn the energy things
    /// </summary>

    private float timeBTweenSpawn2;
    public float StartTimeSpawn2;
    public float decreaseTime2;
    public float minimumTime2 = 0.65f;

    /// <summary>
    /// Spawn the downward effector
    /// </summary>

    public GameObject[] spawnEffector;

    private float timeBTweenSpawn3;
    public float StartTimeSpawn3;
    public float decreaseTime3;
    public float minimumTime3 = 0.65f;


    /// <summary>
    /// UI Things
    /// </summary>

    public static bool isPaused = false;
    public GameObject pauseMenuPanel;

    public GameObject dayImage;
    public GameObject nightImage;

    public void Start()
    {
        canReduce = true;
        reduced = 1;
        isNight = false;
        // nightOrDay.text = "Day";
        //Instantiate(spawnedObsticle, transform.position, Quaternion.identity);
        nightSlider.maxValue = reduction;
        nightSlider.value = reduction;

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
            //nightOrDay.text = "Night";
            nightImage.SetActive(true);
            dayImage.SetActive(false);
        }
        else
        {
            //nightOrDay.text = "Day";
            dayImage.SetActive(true);
            nightImage.SetActive(false);
        }

        dayCounter.text = "Day " + days;

        // Spawning the platforms
        if (!isNight)
        {
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
        }

        if (isNight)
        {
            if (timeBTweenSpawn <= 0)
            {
                int rando = UnityEngine.Random.Range(0, spawnPlatformPatterns2.Length);
                Instantiate(spawnPlatformPatterns2[rando], transform.position, Quaternion.identity);
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



        // Spawning the effector

        /*
        if (timeBTweenSpawn3 <= 0)
        {
            int rando = UnityEngine.Random.Range(0, spawnEffector.Length);
            Instantiate(spawnEffector[rando], transform.position, Quaternion.identity);
            timeBTweenSpawn3 = StartTimeSpawn3;
            if (StartTimeSpawn3 > minimumTime3)
            {
                StartTimeSpawn3 -= decreaseTime3;
            }
        }
        else
        {
            timeBTweenSpawn3 -= Time.deltaTime;

        } */

        // Spawning the energy during the night

        if (isNight)
        {
            nightSlider.value = reduction;

        }
        if (isNight && canReduce)
        {
            StartCoroutine(reduceReduction());
            canReduce = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }

        if (reduction == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    } 

    public void Paused()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    private IEnumerator reduceReduction()
    {
        yield return new WaitForSeconds(5);
        reduction = reduction - reduced;
        canReduce = true;
    }
}
