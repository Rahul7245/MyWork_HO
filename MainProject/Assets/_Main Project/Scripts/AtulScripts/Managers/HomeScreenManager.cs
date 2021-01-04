using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class HomeScreenManager : MonoBehaviour
{
    [SerializeField]
    private ManagerHandler managerHandler;

    public void GoToHomeScreenHomePage(Action OnCompleteTx)
    {
        managerHandler.appStateManager.ToggleApp(AppState.HomeScreen, AppSubState.HomeScreen_HomePage, OnCompleteTx);
        managerHandler.audioManager.PlayAudio(AudioSourceType.ENV, AudioCLips.AC_Pages, true);
    }
    public void PlayWithComputer(Action OnCompleteTx)
    {
        managerHandler.appStateManager.ToggleApp(AppState.HomeScreen, AppSubState.HomeScreen_PlayComputer, OnCompleteTx);
        managerHandler.characterManager.GamePlayingType(GameType.VSComputer);
    }
    public void HandleStartGame(Action OnCompleteTx)
    {
        managerHandler.appStateManager.ToggleApp(AppState.HomeScreen, AppSubState.HomeScreen_PositionAndCap, OnCompleteTx);
        //managerHandler.appStateManager.ToggleApp(AppState.GameScreen, AppSubState.GameScreen_BirdviewMode);
    }

    public void HandlePlayGame(Action OnCompleteTx)
    {
        managerHandler.appStateManager.ToggleApp(AppState.GameScreen, AppSubState.GameScreen_BirdviewMode, OnCompleteTx);
        managerHandler.uIInputHandlerManager.ToggleCardSelection(false);
        managerHandler.audioManager.PlayAudio(AudioSourceType.ENV, AudioCLips.AC_BirdView, true);
    }
    public void OpenSettings(Action OnCompleteTx)
    {
        managerHandler.appStateManager.ToggleApp(AppState.HomeScreen, AppSubState.HomeScreen_SettingPage, OnCompleteTx);
    }
    public void OpenCharaterSelection(Action OnCompleteTx)
    {
        managerHandler.appStateManager.ToggleApp(AppState.HomeScreen, AppSubState.HomeScreen_CharacterSelectionPage, OnCompleteTx);
    }
}
