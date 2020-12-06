﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType
{
    Human,
    Computer
}

[DisallowMultipleComponent]
public class Player : MonoBehaviour
{
    public string playerName = "Player";
    public PlayerType playerType;
    public int LastPointScored;
    public int PlayerScore = 0;
    public Hurdle[] hurdles;
    public void AddToScore(int point)
    {
        PlayerScore += point;
    }
    public void SetScore(int point)
    {
        PlayerScore = point;
    }
}
