﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats_CS : MonoBehaviour
{
    // Start is called before the first frame update
    public static int Money;
    public int startMoney = 400;

    public static int lives;
    public int startLives = 20;

    private void Start()
    {
        Money = startMoney;
        lives = startLives;
    }
}
