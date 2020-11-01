using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using UnityEngine.Video;

public class IntroCanvasHandler : MonoBehaviour 
{
    #region Private Variables 

    [SerializeField]
    private RenderTexture rt;
    [SerializeField]
    private VideoPlayer startVideo;
    [SerializeField]
    private float videoDelay = 1;
    [SerializeField]
	private Slider m_progressBar;
	[SerializeField]
	private float m_barFillDuration = 4;
    [SerializeField]
    private ManagerHandler managerHandler;

    #endregion

    private void Awake()
    {
        rt.DiscardContents();
        rt.Release();
        m_progressBar.onValueChanged.AddListener((value) =>
        {
            if (value == 1)
            {
                managerHandler.appStateManager.ToggleApp(AppState.LoginScreen, AppSubState.LoginScreen_LoginPage);
                startVideo.Stop();
            }
        });
    }
    private void OnDisable()
    {
        rt.DiscardContents();
        rt.Release();
    }

    public void StartLoadingBar () 
	{
		m_progressBar.value = 0;
		m_progressBar.DOValue(1, m_barFillDuration);
        startVideo.Stop();
        StartCoroutine(VideoStart(videoDelay));
	}

    IEnumerator VideoStart(float videoStartDelay)
    {
        yield return new WaitForSecondsRealtime(videoStartDelay);
        startVideo.Play();
    }
}
