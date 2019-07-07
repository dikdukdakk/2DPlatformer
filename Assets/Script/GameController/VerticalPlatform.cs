﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    void LateUpdate()
    {
            if (Input.GetKeyUp(KeyCode.DownArrow))
                waitTime = 0.5f;
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (waitTime <= 1)
                {
                    effector.rotationalOffset = 180f;
                    waitTime = 0.5f;
                }
                else
                    waitTime -= Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.UpArrow))
                effector.rotationalOffset = 0f;     
    }
}