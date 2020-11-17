using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIInputHandlerManager : MonoBehaviour
{
    [SerializeField]
    private ManagerHandler managerHandler;
    public RenderTexture videoTexture;
    public VideoPlayer startVideo;
    public GameObject ScopeCanvas;
    [Header("Login screen buttons and UI intups")]
    public Slider m_progressBar;
    [Header("Login screen buttons and UI intups")]
    public Button LoginButton;

    [Header("PlayComputer screen buttons and UI intups")]
    public Button playWithCompButton;
    public Button OpenSettingButton;
    public Button OpenCharaSelectionButton;

    [Header("PlayComputer screen buttons and UI intups")]
    public Button StartGameButton;
    public Button HomeButton;

    [Header("Setting Page screen buttons and UI intups")]
    public Button HomeButtonSetting;

    [Header("Charater selection screen buttons and UI intups")]
    public CharacterButton characterButton_0;
    public CharacterButton characterButton_1;
    public CharacterButton characterButton_2;
    public CharacterButton characterButton_3;
    public CharacterButton characterButton_4;
    public CharacterButton characterButton_5;
    public Button HomeButtonCharater;
    public Button selectButton;
    public List<GameObject> CharacterImages;
    public List<GameObject> CharacterModels;

    [Header("List of character prefabs in shooting screen")]
    public List<GameObject> charactersPrefabsList;

    private void Awake()
    {
        LoginButton.onClick.AddListener(managerHandler.loginManager.HandleLogin);
        playWithCompButton.onClick.AddListener(managerHandler.homeScreenManager.PlayWithComputer);
        StartGameButton.onClick.AddListener(managerHandler.homeScreenManager.HandleStartGame);
        OpenSettingButton.onClick.AddListener(managerHandler.homeScreenManager.OpenSettings);
        OpenCharaSelectionButton.onClick.AddListener(managerHandler.homeScreenManager.OpenCharaterSelection);
        HomeButton.onClick.AddListener(managerHandler.homeScreenManager.GoToHomeScreen);
        HomeButtonSetting.onClick.AddListener(managerHandler.homeScreenManager.GoToHomeScreen);
        HomeButtonCharater.onClick.AddListener(managerHandler.homeScreenManager.GoToHomeScreen);
        // Character selection screen
        characterButton_0.onClick.AddListener(() => { managerHandler.characterManager.CharacterButtonClicked(0); });
        characterButton_1.onClick.AddListener(() => { managerHandler.characterManager.CharacterButtonClicked(1); });
        characterButton_2.onClick.AddListener(() => { managerHandler.characterManager.CharacterButtonClicked(2); });
        characterButton_3.onClick.AddListener(() => { managerHandler.characterManager.CharacterButtonClicked(3); });
        characterButton_4.onClick.AddListener(() => { managerHandler.characterManager.CharacterButtonClicked(4); });
        characterButton_5.onClick.AddListener(() => { managerHandler.characterManager.CharacterButtonClicked(5); });
    }
}
