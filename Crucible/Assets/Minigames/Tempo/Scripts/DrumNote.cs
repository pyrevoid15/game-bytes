﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumNote : MonoBehaviour
{
    public float hitTime;
    public float shrinkRate;

    public void initialize(float hitTime, float approachTime)
    {
        this.hitTime = hitTime;
        shrinkRate = (2 - 0.6f) / approachTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localScale.x >= 0)
            gameObject.transform.localScale -= shrinkRate * new Vector3(1, 1, 0) * Time.deltaTime;
    }
}
