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
public enum AppSubState
{
    None = 0,
    LoginScreen_LoginPage,
    LoginScreen_SignupPage,
    HomeScreen_HomePage,
    HomeScreen_SettingPage,
    HomeScreen_CharacterSelectionPage,
    HomeScreen_PlayComputer,
    GameScreen_BirdviewMode,
    GameScreen_ShootingMode
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
        CurrentScreenGameObject.SetActive(false);
    }
    public virtual void OnEnter()
    {
    }
    public virtual void OnExit()
    {
    }
}
