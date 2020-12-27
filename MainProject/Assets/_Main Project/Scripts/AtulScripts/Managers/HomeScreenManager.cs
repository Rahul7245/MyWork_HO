using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class HomeScreenManager : MonoBehaviour
{
    [SerializeField]
    private ManagerHandler managerHandler;

    public void GoToHomeScreenHomePage()
    {
        managerHandler.appStateManager.ToggleApp(AppState.HomeScreen, AppSubState.HomeScreen_HomePage);
        managerHandler.audioManager.PlayAudio(AudioSourceType.ENV, AudioCLips.AC_Pages, true);
    }
    public void PlayWithComputer()
    {
        managerHandler.appStateManager.ToggleApp(AppState.HomeScreen, AppSubState.HomeScreen_PlayComputer);
        managerHandler.characterManager.GamePlayingType(GameType.VSComputer);
    }
    public void HandleStartGame()
    {
        managerHandler.appStateManager.ToggleApp(AppState.HomeScreen, AppSubState.HomeScreen_PositionAndCap);
        //managerHandler.appStateManager.ToggleApp(AppState.GameScreen, AppSubState.GameScreen_BirdviewMode);
    }

    public void HandlePlayGame()
    {
        managerHandler.appStateManager.ToggleApp(AppState.GameScreen, AppSubState.GameScreen_BirdviewMode);
        managerHandler.uIInputHandlerManager.ToggleCardSelection(false);
        managerHandler.audioManager.PlayAudio(AudioSourceType.ENV, AudioCLips.AC_BirdView, true);
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
