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
        managerHandler.characterManager.SelectCharaterForGame();
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
        int charIndex = PlayerPrefManager.GetPlayerPrefInt(PlayerPrefKeys.CharacterSeleted_INT, 0);
        if (charIndex == 0)
        {
            managerHandler.audioManager.PlayAudio(AudioSourceType.ENV, AudioCLips.AC_Character01_selection, true);
        }
        if (charIndex == 1)
        {
            managerHandler.audioManager.PlayAudio(AudioSourceType.ENV, AudioCLips.AC_Character02_selection, true);
        }
        if (charIndex == 2)
        {
            managerHandler.audioManager.PlayAudio(AudioSourceType.ENV, AudioCLips.AC_Character03_selection, true);
        }
        if (charIndex == 3)
        {
            managerHandler.audioManager.PlayAudio(AudioSourceType.ENV, AudioCLips.AC_Character04_selection, true);
        }
        if (charIndex == 4)
        {
            managerHandler.audioManager.PlayAudio(AudioSourceType.ENV, AudioCLips.AC_Character05_selection, true);
        }
        if (charIndex == 5)
        {
            managerHandler.audioManager.PlayAudio(AudioSourceType.ENV, AudioCLips.AC_Character06_selection, true);
        }
        managerHandler.appStateManager.ToggleApp(AppState.HomeScreen, AppSubState.HomeScreen_CharacterSelectionPage, OnCompleteTx);
    }
}
