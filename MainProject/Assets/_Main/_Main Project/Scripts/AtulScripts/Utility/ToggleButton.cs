using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public class ToggleButton : Button
{
    public Action<bool> OnBtnToggled;
    [SerializeField]
    public Image imageOn;
    [SerializeField]
    public Image imageOff;
    private bool isTurnOn = true;

    public void SetDefault(bool status)
    {
        Debug.Log("## Turing : " + status);
        isTurnOn = !status;
        ToggleLogic();
    }

    protected override void Awake()
    {
        onClick.AddListener(ToggleLogic);
    }

    private void ToggleLogic()
    {
        isTurnOn = !isTurnOn;
        imageOn.gameObject.SetActive(isTurnOn);
        imageOff.gameObject.SetActive(!isTurnOn);
        OnBtnToggled?.Invoke(isTurnOn);
    }
}
