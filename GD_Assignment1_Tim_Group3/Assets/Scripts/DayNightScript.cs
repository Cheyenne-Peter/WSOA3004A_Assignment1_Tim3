using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Experimental.Rendering.Universal;

public class DayNightScript : MonoBehaviour
{
    [SerializeField] private Gradient lightcolor;
    [SerializeField] private new GameObject light;

    private int days;

    public int Days => days;

    private float time = 1;

    private bool canChangeDay = true;

    public delegate void onDayChanged();

    public onDayChanged dayChanged;

    public bool isNight;

    public Text nightOrDay;
    public Text dayCounter;

    public void Start()
    {
        isNight = false;
        nightOrDay.text = "Day";
    }
    private void Update()
    {
        if (time > 120)
        {
            time = 0;
        }

        if ((int) time == 120 && canChangeDay)
        {
            canChangeDay = false;
            days++;
            //dayChanged();

        }

        if ((int)time == 1)
            canChangeDay = true;

        time += Time.deltaTime;
        light.GetComponent<Light2D>().color = lightcolor.Evaluate(time * 0.00825f);

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

        dayCounter.text = "Day" + days;

    }


}