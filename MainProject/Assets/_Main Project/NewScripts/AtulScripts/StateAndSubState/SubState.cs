using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

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
    GameScreen_ShootingMode,
    GameScreen_ScopeMode
}

[RequireComponent(typeof(CanvasGroup))]
public abstract class SubState : MonoBehaviour
{
    [SerializeField]
    protected bool showExitTransition = false;
    [SerializeField]
    protected AppSubState appSubState;
    [SerializeField]
    protected CanvasGroup currentCanvasGrup;
    [SerializeField]
    protected CanvasGroup subStateTranistionCanvasGrup;
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
        if (showExitTransition)
        {
            StartCoroutine(SubStateExitTransitionEffect());
        }
        else
        {
            currentCanvasGrup.alpha = 0;
            CurrentScreenGameObject.SetActive(false);
        }
    }

    private IEnumerator SubStateExitTransitionEffect()
    {
        subStateTranistionCanvasGrup.alpha = 1;
        subStateTranistionCanvasGrup.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        managerHandler.appStateManager.ToggleFade(subStateTranistionCanvasGrup, 0, 0.5f, () => { subStateTranistionCanvasGrup.gameObject.SetActive(false);
            currentCanvasGrup.alpha = 0;
            CurrentScreenGameObject.SetActive(false);
        });
    }
}
