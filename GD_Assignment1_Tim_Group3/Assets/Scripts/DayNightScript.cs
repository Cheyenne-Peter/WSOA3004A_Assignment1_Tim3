using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Experimental.Rendering.Universal;

public class DayNightScript : MonoBehaviour
{
    [SerializeField] private Gradient lightcolor;
    [SerializeField] private GameObject light;

    private int days;

    public int Days => days;

    private float time = 1;

    private bool canChangeDay = true;

    public delegate void onDayChanged();

    public onDayChanged dayChanged;

    private void Update()
    {
        if (time > 120)
        {
            time = 0;
        }

        if ((int) time == 60 && canChangeDay)
        {
            canChangeDay = false;
            //dayChanged();
            days++;
        }

        if ((int)time == 65)
            canChangeDay = true;

        time += Time.deltaTime;
        light.GetComponent<Light2D>().color = lightcolor.Evaluate(time * 0.01f);

    }


}