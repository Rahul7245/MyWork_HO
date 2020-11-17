﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class HomeScreenManager : MonoBehaviour
{
    [SerializeField]
    private ManagerHandler managerHandler;

    public void GoToHomeScreen()
    {
        managerHandler.appStateManager.ToggleApp(AppState.HomeScreen, AppSubState.HomeScreen_HomePage);
    }
    public void PlayWithComputer()
    {
        managerHandler.appStateManager.ToggleApp(AppState.HomeScreen, AppSubState.HomeScreen_PlayComputer);
    }
    public void HandleStartGame()
    {
        managerHandler.appStateManager.ToggleApp(AppState.GameScreen, AppSubState.GameScreen_BirdviewMode);
    }
    public void OpenSettings()
    {
        managerHandler.appStateManager.ToggleApp(AppState.HomeScreen, AppSubState.HomeScreen_SettingPage);
    }
    public void OpenCharaterSelection()
    {
        managerHandler.appStateManager.ToggleApp(AppState.HomeScreen, AppSubState.HomeScreen_CharacterSelectionPage);
    }
}
