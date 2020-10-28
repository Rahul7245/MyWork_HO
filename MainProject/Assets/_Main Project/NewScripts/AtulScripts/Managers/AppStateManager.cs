using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppStateManager : MonoBehaviour
{
    public float SubStateDelay = 2;
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
    private Coroutine StateCR;
    private Coroutine SubStateCR;

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
        if(StateCR != null)
        {
            StopCoroutine(StateCR);
        }
        StateCR = StartCoroutine(ToggleAppState(appState));
        if (SubStateCR != null)
        {
            StopCoroutine(StateCR);
        }
        SubStateCR = StartCoroutine(ToggleAppSubState(appState, appSubState));
    }

    private IEnumerator ToggleAppState(AppState appState)
    {
        if (currentAppState == appState)
        {
            StateCR = null;
            yield break;
        }
        // if have old state first exit then enter bew state
        if (currentState)
        {
            if (currentState.ShowExitTransition)
            {
                yield return StartCoroutine(currentState.OnExit());
            }
            else
            {
                StartCoroutine(currentState.OnExit());
            }
        }
        currentAppState = appState;
        currentState = GetTheState(appState);
        if (currentState)
        {
            if (currentState.ShowEnterTransition)
            {
                yield return StartCoroutine(currentState.OnEnter());
            }
            else
            {
                StartCoroutine(currentState.OnEnter());
            }
        }
        StateCR = null;
    }

    private IEnumerator ToggleAppSubState(AppState appState, AppSubState appSubState)
    {
        if (currentAppSubState == appSubState)
        {
            SubStateCR = null;
            yield break;
        }
        // if have old state first exit then enter bew state
        if (currentSubState)
        {
            if (currentSubState.ShowExitTransition)
            {
                yield return StartCoroutine(currentSubState.OnExit());
            }
            else
            {
                StartCoroutine(currentSubState.OnExit());
            }
        }
        currentAppSubState = appSubState;
        currentSubState = GetTheSubState(appState, appSubState);
        if (currentSubState)
        {
            if (currentSubState.ShowEnterTransition)
            {
                yield return StartCoroutine(currentSubState.OnEnter());
            }
            else
            {
                StartCoroutine(currentSubState.OnEnter());
            }
        }
        SubStateCR = null;
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

    public void ToggleFade(CanvasGroup canvasGroup, float amount, float m_duration = 0.5f, TweenCallback ToggleDone = null)
    {
        Tween tween = canvasGroup.DOFade(amount, m_duration);
        tween.onComplete = ToggleDone;
    }
}
