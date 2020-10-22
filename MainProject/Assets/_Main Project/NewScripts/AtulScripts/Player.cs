using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType
{
    Human,
    Computer
}
public class Player : MonoBehaviour
{
    public string playerName = "Player";
    public PlayerType playerType;
    public int LastPointScored;
    public int PlayerScore = 0;

    public void AddToScore(int point)
    {
        PlayerScore += point;
    }
}
