﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUP : MonoBehaviour
{
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed*Time.deltaTime, 0);
    }
}
