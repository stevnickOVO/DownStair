﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="enemyProper",menuName = "enemy/property")]
public class enemyScriptTableObject : ScriptableObject
{
    public float speed;
    public float MaxHP;
    public float attackVaule;
    public float currHp;
    public float enemyEXP;
    public int coinRangeMin;
    public int coinRangeMax;
    public GameObject coinPefabs;
    private void Awake()
    {
        currHp = MaxHP;
    }
}
