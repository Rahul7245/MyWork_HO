using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInputHandlerManager : MonoBehaviour
{
    [SerializeField]
    private ManagerHandler managerHandler;
    public Button LoginButton;
    public Button playWithCompButton;
    public Button StartGameButton;
    public Button OpenSettingButton;
    public Button OpenCharaSelectionButton;
    public Button HomeButton;
    public Button HomeButtonSetting;
    public Button HomeButtonCharater;
    /// <summary>
    ///  Game object6s 
    /// </summary>
    public GameObject ScopeCanvas;

    private void Awake()
    {
        LoginButton.onClick.AddListener(HandleLogin);
        playWithCompButton.onClick.AddListener(PlayWithComputer);
        StartGameButton.onClick.AddListener(HandleStartGame);
        OpenSettingButton.onClick.AddListener(OpenSettings);
        OpenCharaSelectionButton.onClick.AddListener(OpenCharaterSelection);
        HomeButton.onClick.AddListener(HandleLogin);
        HomeButtonSetting.onClick.AddListener(HandleLogin);
        HomeButtonCharater.onClick.AddListener(HandleLogin);
    }
    private void HandleLogin()
    {
        managerHandler.appStateManager.ToggleApp(AppState.HomeScreen, AppSubState.HomeScreen_HomePage);
    }
    private void PlayWithComputer()
    {
        managerHandler.appStateManager.ToggleApp(AppState.HomeScreen, AppSubState.HomeScreen_PlayComputer);
    }
    private void HandleStartGame()
    {
        managerHandler.appStateManager.ToggleApp(AppState.GameScreen, AppSubState.GameScreen_BirdviewMode);
    }
    private void OpenSettings()
    {
        managerHandler.appStateManager.ToggleApp(AppState.HomeScreen, AppSubState.HomeScreen_SettingPage);
    }
    private void OpenCharaterSelection()
    {
        managerHandler.appStateManager.ToggleApp(AppState.HomeScreen, AppSubState.HomeScreen_CharacterSelectionPage);
    }
}
