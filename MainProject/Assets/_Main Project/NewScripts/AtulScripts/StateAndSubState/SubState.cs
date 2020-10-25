﻿using System.Collections;
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
    protected bool showEnterTransition = false;
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
        if (showEnterTransition)
        {
            SubStateEnterTransitionEffect();
        }
        else
        {
            currentCanvasGrup.alpha = 1;
            CurrentScreenGameObject.SetActive(true);
        }
    }
    public  virtual void OnExit()
    {
        if (showExitTransition)
        {
            SubStateExitTransitionEffect();
        }
        else
        {
            currentCanvasGrup.alpha = 0;
            CurrentScreenGameObject.SetActive(false);
        }
            
    }

    private void SubStateEnterTransitionEffect()
    {
        currentCanvasGrup.alpha = 0;
        subStateTranistionCanvasGrup.alpha = 1;
        CurrentScreenGameObject.SetActive(true);
        subStateTranistionCanvasGrup.gameObject.SetActive(true);
        managerHandler.appStateManager.ToggleFade(currentCanvasGrup, 1, 1, null);
        managerHandler.appStateManager.ToggleFade(subStateTranistionCanvasGrup, 0, 1f, ()=> { managerHandler.appStateManager.ToggleFade(subStateTranistionCanvasGrup, 0, 2, () => { subStateTranistionCanvasGrup.gameObject.SetActive(false); }); });
        
    }

    private void SubStateExitTransitionEffect()
    {
        currentCanvasGrup.alpha = 1;
        subStateTranistionCanvasGrup.alpha = 0;
        CurrentScreenGameObject.SetActive(true);
        subStateTranistionCanvasGrup.gameObject.SetActive(true);
        managerHandler.appStateManager.ToggleFade(currentCanvasGrup, 0,1, null);
        managerHandler.appStateManager.ToggleFade(subStateTranistionCanvasGrup, 1, 0.5f, ()=> { managerHandler.appStateManager.ToggleFade(subStateTranistionCanvasGrup, 0, 1.5f, () => { subStateTranistionCanvasGrup.gameObject.SetActive(false); }); });
    }
}
