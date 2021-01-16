using GammaXR.UI;
using System;
using UnityEngine;

public enum PlayerType
{
    Human,
    Computer
}

[DisallowMultipleComponent]
public class Player : MonoBehaviour
{
    public int ID;
    private string playerName = "Player";
    public PlayerType playerType;
    public int LastPointScored;
    public int PlayerScore = 0;
    public Hurdle[] hurdles;
    public bool Skip=false;
    public Sprite playerSprite;
    [HideInInspector]
    public CharactersProperty charactersProperty;

    public string PlayerName { get => playerName; set => playerName = value; }

    private void Start()
    {
        PlayerScore = 0;
        if (charactersProperty != null)
        {
            charactersProperty.SetPoint(PlayerScore.ToString());
        }
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
        if (charactersProperty != null)
        {
            charactersProperty.SetPoint(PlayerScore.ToString());
        }
        return true;
    }
    public void SetScore(int point)
    {
        PlayerScore = point;
        if (charactersProperty != null)
        {
            charactersProperty.SetPoint(PlayerScore.ToString());
        }
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
