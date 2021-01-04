using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public enum AppSubState
{
    None = 0,
    LoginScreen_LoginPage,
    LoginScreen_SignupPage,
    HomeScreen_HomePage,
    HomeScreen_SettingPage,
    HomeScreen_CharacterSelectionPage,
    HomeScreen_PlayComputer,
    HomeScreen_PositionAndCap,
    GameScreen_BirdviewMode,
    GameScreen_ShootingMode,
    GameScreen_ScopeMode
}

[RequireComponent(typeof(CanvasGroup))]
public abstract class SubState : MonoBehaviour
{
    [SerializeField]
    protected AppSubState appSubState;
    [SerializeField]
    protected CanvasGroup currentCanvasGrup;
    [SerializeField]
    protected CanvasGroup subStateTranistionCanvasGrup;
    [SerializeField]
    protected VideoPlayer player;
    [SerializeField]
    protected ManagerHandler managerHandler;

    public GameObject CurrentScreenGameObject
    {
        get
        {
            return this.gameObject;
        }
    }

    public AppSubState AppSubState
    {
        get
        {
            return appSubState;
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
    public  virtual void OnExit()
    {
        currentCanvasGrup.alpha = 0;
        CurrentScreenGameObject.SetActive(false);
    }

}
