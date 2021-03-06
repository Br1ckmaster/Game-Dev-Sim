﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLine : MonoBehaviour
{
    [Range(0.1f, 100f)]
    public float radius = 1.0f;

    [Range(3, 256)]
    public int numSegments = 256;

    void Start()
    {
        RenderLine();
    }

    void Update()
    {
        RenderLine();
    }

    public void RenderLine()
    {
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.positionCount = numSegments + 1;
        lineRenderer.useWorldSpace = false;

        float deltaTheta = (float)(2.0 * Mathf.PI) / numSegments;
        float theta = 0f;

        for (int i = 0; i < numSegments + 1; i++)
        {
            float x = radius * Mathf.Cos(theta);
            float z = radius * Mathf.Sin(theta);
            Vector3 pos = new Vector3(x, 0.5f, z);
            lineRenderer.SetPosition(i, pos);
            theta += deltaTheta;
        }
    }
}
