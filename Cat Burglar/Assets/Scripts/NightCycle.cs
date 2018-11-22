﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightCycle : MonoBehaviour
{
    [SerializeField]
    private Light sun;
    [SerializeField]
    private float secondsInFullDay = 120f; //how many seconds in a day

   
    [SerializeField]
    [Range(0, 1)] private float currentTimeOfDay = 0; //slider in inspector

    public PlayerLine playerOneRadius;
    public PlayerLine playerTwoRadius;

    public EnemyOne enemyOneDetectionP1;
    public EnemyOne enemyOneDetectionP2;

    private float timeMultiplier = 1f;
    private float sunInitialIntensity;

    void Start()
    {
        sunInitialIntensity = sun.intensity; //sun is equal to the directional light intensity

    }

    void Update()
    {
        UpdateSun();
        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier; //current time of day over time every frame divide by the seconds in a day then times it by the time multiplier

        if (currentTimeOfDay >= 0.28f)
        {
            currentTimeOfDay = 0.28f; //resets day
            playerOneRadius.radius = 20;
            enemyOneDetectionP1.enemyRadiusP1 = 24;
        }
    }

    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 75, 260, 0); //transform rotation of sun //170 is horizon

        float intensityMultiplier = 1; //changes light intensity of sun

        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f) //if sun is just before sunrise or sunset
        {
            intensityMultiplier = 0; //set intensity of sun to 0
        }

        else if (currentTimeOfDay <= 0.25f) //if below 0.25
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f)); //set intensity value between 0 and 1 which is the value just before sunrise allow it to fade in
        }
        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }
}

