using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppStateManager : MonoBehaviour
{
    [SerializeField]
    private ManagerHandler managerHandler;
    public static AppStateManager instance;
    [SerializeField]
    private float m_duration = 0.5f;
    [SerializeField]
    private List<State> appStates;
    [SerializeField]
    private AppState currentAppState;
    private State currentState;
    [SerializeField]
    private AppSubState currentAppSubState;
    private SubState currentSubState;

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

    void Awake()
    {
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
        ToggleApp(AppState.LoadingScreen, AppSubState.None);
    }
    public void ToggleApp(AppState appState, AppSubState appSubState)
    {
        Debug.Log("ToggleApp called with appState : " + appState + " appSubState : " + appSubState);
        ToggleAppState(appState);
        ToggleAppSubState(appState, appSubState);
    }

    private void ToggleAppState(AppState appState)
    {
        Debug.Log("ToggleAppState called with appState : " + appState);
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

    private void ToggleAppSubState(AppState appState, AppSubState appSubState)
    {
        Debug.Log("ToggleAppSubState called with appState : " + appState + " appSubState : " + appSubState);
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

    public void ToggleFade(CanvasGroup canvasGroup, float amount, TweenCallback ToggleDone = null)
    {
        Tween tween = canvasGroup.DOFade(amount, m_duration);
        tween.onComplete = ToggleDone;
    }
}
