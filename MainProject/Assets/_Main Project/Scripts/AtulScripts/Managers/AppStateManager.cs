using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppStateManager : MonoBehaviour
{
    public float SubStateDelay = 1.00f;
    [SerializeField]
    private ManagerHandler managerHandler;
    public static AppStateManager instance;
    [SerializeField]
    private List<State> appStates;
    [SerializeField]
    private AppState currentAppState;
    private State currentState;
    [SerializeField]
    private AppSubState currentAppSubState;
    private SubState currentSubState;

    private AppState previousState;
    private AppSubState previousSubState;
    public AppState CurrentAppState
    {
        get
        {
            return currentAppState;
        }
    }

    public AppSubState CurrentAppSubState
    {
        get
        {
            return currentAppSubState;
        }
    }


    #region Unity Functions

    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    // Use this for initialization
    void Start()
    {
        currentState = appStates[0];
        ToggleApp(AppState.LoadingScreen, AppSubState.None, null);
    }

    #endregion

    #region Public Functions 

    public void ToggleApp(AppState appState, AppSubState appSubState, Action OnCompleteTx, bool _showTransistion = false)
    {
        if (!_showTransistion)
        {
            ToggleHelper(appState, appSubState, OnCompleteTx);
        }
        else
        {
            managerHandler.videoTransistionManager.animationEvents.OnAimationMid += ()=> 
            { 
                ToggleHelper(appState, appSubState, OnCompleteTx);
                managerHandler.videoTransistionManager.animationEvents.OnAimationMid = null;
            };
            managerHandler.videoTransistionManager.animationEvents.OnAnimationStart += () =>
            {
                managerHandler.audioManager.PlayAudio(AudioSourceType.ANIMEF, AudioCLips.AC_Vedio_Png, false);
                managerHandler.videoTransistionManager.animationEvents.OnAnimationStart = null;
            };
            managerHandler.videoTransistionManager.StartTranistion();
        }
    }

    public void ToggleFade(CanvasGroup canvasGroup, float amount, float m_duration = 0.5f, TweenCallback ToggleDone = null)
    {
        Tween tween = canvasGroup.DOFade(amount, m_duration);
        tween.onComplete = ToggleDone;
    }

    public void BackPressed()
    {
        ToggleApp(previousState, previousSubState, null);
    }

    #endregion

    #region Private Functions

    private void ToggleHelper(AppState appState, AppSubState appSubState, Action OnCompleteTx)
    {
        previousState = currentAppState;
        previousSubState = currentAppSubState;
        ToggleAppState(appState);
        ToggleAppSubState(appState, appSubState, OnCompleteTx);
    }

    private void ToggleAppState(AppState appState)
    {
        if (currentAppState == appState)
        {
            return;
        }
        // if have old state first exit then enter bew state
        if (currentState)
        {
            currentState.OnExit();
        }
        currentAppState = appState;
        currentState = GetTheState(appState);
        if (currentState)
        {
            currentState.OnEnter();
        }
    }

    private void ToggleAppSubState(AppState appState, AppSubState appSubState, Action OnCompleteTx)
    {
        if (currentAppSubState == appSubState)
        {
            return;
        }
        // if have old state first exit then enter bew state
        if (currentSubState)
        {
            currentSubState.OnExit();
        }
        currentAppSubState = appSubState;
        currentSubState = GetTheSubState(appState, appSubState);
        if (currentSubState)
        {
            currentSubState.OnEnter();
        }
        OnCompleteTx?.Invoke();
    }

    private State GetTheState(AppState state)
    {
        if (appStates != null && appStates.Count > 0)
        {
            foreach (State appState in appStates)
            {
                if (appState.AppState == state)
                {
                    return appState;
                }
            }
        }

        return null;
    }

    private SubState GetTheSubState(AppState state, AppSubState subState)
    {
        if (appStates != null && appStates.Count > 0)
        {
            foreach (State appState in appStates)
            {
                if (appState.AppState == state)
                {
                    if (appState.AppSubStates != null && appState.AppSubStates.Count > 0)
                    {
                        foreach (SubState appSubState in appState.AppSubStates)
                        {
                            if (appSubState.AppSubState == subState)
                            {
                                return appSubState;
                            }
                        }
                    }
                }
            }
        }

        return null;
    }

    #endregion
}
