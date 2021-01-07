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
    private float videoDelay = 1;
	[SerializeField]
	private float m_barFillDuration = 4;
    [SerializeField]
    private ManagerHandler managerHandler;

    #endregion

    private void Awake()
    {
        managerHandler.uIInputHandlerManager.videoTexture.DiscardContents();
        managerHandler.uIInputHandlerManager.videoTexture.Release();
        managerHandler.uIInputHandlerManager.m_progressBar.onValueChanged.AddListener((value) =>
        {
            if (value == 1)
            {
                managerHandler.appStateManager.ToggleApp(AppState.LoginScreen, AppSubState.LoginScreen_LoginPage,null);
                managerHandler.uIInputHandlerManager.startVideo.Stop();
                managerHandler.audioManager.PlayAudio(AudioSourceType.ENV, AudioCLips.AC_Pages, true);
            }
        });
    }
    private void OnDisable()
    {
        managerHandler.uIInputHandlerManager.videoTexture.DiscardContents();
        managerHandler.uIInputHandlerManager.videoTexture.Release();
    }

    public void StartLoadingBar () 
	{
        managerHandler.uIInputHandlerManager.m_progressBar.value = 0;
        managerHandler.uIInputHandlerManager.m_progressBar.DOValue(1, m_barFillDuration);
        managerHandler.uIInputHandlerManager.startVideo.Stop();
        StartCoroutine(VideoStart(videoDelay));
	}

    IEnumerator VideoStart(float videoStartDelay)
    {
        yield return new WaitForSecondsRealtime(videoStartDelay);
        managerHandler.uIInputHandlerManager.startVideo.Play();
    }
}
