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

    public virtual IEnumerator OnEnter()
    {
        currentCanvasGrup.alpha = 1;
        CurrentScreenGameObject.SetActive(true);
        yield return null;
    }
    public  virtual IEnumerator OnExit()
    {
        if (showExitTransition)
        {
            yield return StartCoroutine(SubStateExitTransitionEffect());
        }
        else
        {
            currentCanvasGrup.alpha = 0;
            CurrentScreenGameObject.SetActive(false);
        }
        yield return null;
    }

    private IEnumerator SubStateExitTransitionEffect()
    {
        subStateTranistionCanvasGrup.alpha = 1;
        subStateTranistionCanvasGrup.gameObject.SetActive(true);
        player.targetCameraAlpha = 0;
        while(player.targetCameraAlpha < 1)
        {
            yield return null;
            player.targetCameraAlpha += Time.fixedDeltaTime;
        }
        yield return new WaitForSecondsRealtime(1.5f);
        while (player.targetCameraAlpha > 0)
        {
            yield return null;
            player.targetCameraAlpha -= Time.fixedDeltaTime;
        }
        subStateTranistionCanvasGrup.gameObject.SetActive(false);
        currentCanvasGrup.alpha = 0;
        CurrentScreenGameObject.SetActive(false);
    }
}
