using GammaXR.UI;
using System.Collections;
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
    public bool Skip=false;
    public CharactersProperty charactersProperty;
    private void Start()
    {
        Skip = false;
    }
    public bool AddToScore(int point)
    {
        if (PlayerScore == 21&&point==1) {
            PlayerScore += point;
            return true;
        }
        if (((PlayerScore + point) > 21) || ((PlayerScore + point) < 0)) {
            return false;
        }
        PlayerScore += point;
        return true;
    }
    public void SetScore(int point)
    {
        PlayerScore = point;
    }

    public void SetSkip(bool skip)
    {
        Skip = skip;
    }

    public bool GetSkip()
    {
        return Skip;
    }
}
