﻿using System.Collections;
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
public abstract class State : MonoBehaviour
{
    [SerializeField]
    protected AppState appState;
    [SerializeField]
    protected List<SubState> appSubStates;

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

    public virtual void OnEnter()
    {
    }
    public virtual void OnExit()
    {
    }
}
