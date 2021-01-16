using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerInfo : MonoBehaviour
{
    public Button btn;
    public TextMeshProUGUI playerName;
    public Image playerImage;

    private void SetPlayerImage(Sprite _sprite)
    {
        playerImage.sprite = _sprite;
    }
    private void SetPlayerName(string _name)
    {
        playerName.text = _name;
    }
    private void SetBtnEvent(Action btnEvent)
    {
        btn.onClick.AddListener(()=> { btnEvent?.Invoke(); });
    }

    public void SetPlayerInfo(Sprite _sprite, string _name, Action btnEvent)
    {
        SetPlayerImage(_sprite);
        SetPlayerName(_name);
        SetBtnEvent(btnEvent);
    }
}
