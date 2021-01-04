using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AppState
{
    None = 0,
    LoadingScreen,
    LoginScreen,
    HomeScreen,
    GameScreen
}

[RequireComponent(typeof(CanvasGroup))]
public abstract class State : MonoBehaviour
{
    [SerializeField]
    protected AppState appState;
    [SerializeField]
    protected List<SubState> appSubStates;
    [SerializeField]
    protected CanvasGroup currentCanvasGrup;
    [SerializeField]
    protected ManagerHandler managerHandler;

    public GameObject CurrentScreenGameObject
    {
        get
        {
            return this.gameObject;
        }
    }

    public AppState AppState
    {
        get
        {
            return appState;
        }
    }

    public List<SubState> AppSubStates
    {
        get
        {
            return appSubStates;
        }
    }

    protected virtual void Awake()
    {
        //CurrentScreenGameObject.SetActive(false);
    }
    public virtual void OnEnter()
    {
        currentCanvasGrup.alpha = 1;
        CurrentScreenGameObject.SetActive(true);
    }
    public virtual void OnExit()
    {
        currentCanvasGrup.alpha = 0;
        CurrentScreenGameObject.SetActive(false);
    }
}
