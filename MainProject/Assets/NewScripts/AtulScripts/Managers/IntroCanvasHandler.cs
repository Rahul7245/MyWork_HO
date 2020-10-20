using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class IntroCanvasHandler : MonoBehaviour 
{
    #region Private Variables 

    [SerializeField]
	private Slider m_progressBar;
	[SerializeField]
	private float m_barFillDuration = 4;
    [SerializeField]
    private ManagerHandler managerHandler;

    #endregion

    private void Awake()
    {
        m_progressBar.onValueChanged.AddListener((value) =>
        {
            if (value == 1)
            {
                managerHandler.appStateManager.ToggleApp(AppState.LoginScreen, AppSubState.LoginScreen_LoginPage);
            }
        });
    }

    public void StartLoadingBar () 
	{
		m_progressBar.value = 0;
		m_progressBar.DOValue(1, m_barFillDuration);
	}
}
