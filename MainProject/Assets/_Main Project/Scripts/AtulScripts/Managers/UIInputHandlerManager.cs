﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using DG.Tweening;

public class UIInputHandlerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject PopupPrefab;
    [SerializeField]
    private ManagerHandler managerHandler;
    public RenderTexture videoTexture;
    public VideoPlayer startVideo;
    public GameObject ScopeCanvas;
    [Header("Login screen buttons and UI intups")]
    public Slider m_progressBar;
    [Header("Login screen buttons and UI intups")]
    public Button LoginButton;

    [Header("Home screen buttons and UI intups")]
    public Button playWithCompButton;
    public Button OpenSettingButton;
    public Button OpenCharaSelectionButton;
    public List<Sprite> charatersSprites;

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

    public List<GameObject> cardShuffel_;
    public AnimationEndEvent cardShuffleDone;
    public AnimationEndEvent cardReveal;
    public List<ThreeDObjButton> threeDObjButtons;
    public Button back;
    public Button shootButton;

    private void Awake()
    {
        back.onClick.AddListener(managerHandler.appStateManager.BackPressed);
        LoginButton.onClick.AddListener(managerHandler.loginManager.HandleLogin);
        // Home screen buttons
        playWithCompButton.onClick.AddListener(managerHandler.homeScreenManager.PlayWithComputer);
        OpenSettingButton.onClick.AddListener(managerHandler.homeScreenManager.OpenSettings);
        OpenCharaSelectionButton.onClick.AddListener(managerHandler.homeScreenManager.OpenCharaterSelection);
        // Home screen buttons end

        // PlaywithComputer screen buttons
        StartGameButton.onClick.AddListener(managerHandler.homeScreenManager.HandleStartGame);
        cardReveal.OnAnimationEnd += managerHandler.homeScreenManager.HandlePlayGame;
        cardShuffleDone.OnAnimationEnd += () => { ToggleCardSelection(true); };
        HomeButton.onClick.AddListener(managerHandler.homeScreenManager.GoToHomeScreen);
        // PlaywithComputer screen buttons end

        // Setting screen buttons
        HomeButtonSetting.onClick.AddListener(managerHandler.homeScreenManager.GoToHomeScreen);
        // Setting screen buttons end

        // Character selection screen buttons
        HomeButtonCharater.onClick.AddListener(managerHandler.homeScreenManager.GoToHomeScreen);
        characterButton_0.onClick.AddListener(() => { managerHandler.characterManager.CharacterButtonClicked(0); });
        characterButton_1.onClick.AddListener(() => { managerHandler.characterManager.CharacterButtonClicked(1); });
        characterButton_2.onClick.AddListener(() => { managerHandler.characterManager.CharacterButtonClicked(2); });
        characterButton_3.onClick.AddListener(() => { managerHandler.characterManager.CharacterButtonClicked(3); });
        characterButton_4.onClick.AddListener(() => { managerHandler.characterManager.CharacterButtonClicked(4); });
        characterButton_5.onClick.AddListener(() => { managerHandler.characterManager.CharacterButtonClicked(5); });
        selectButton.onClick.AddListener(() => { managerHandler.characterManager.SelectCharaterForGame();
            ShowPopup(0, Constants.Msg_CharacterSelected);
        });
        // Character selection screen buttons end
        ClickedOnCard();

    }

    public void ToggleCardSelection(bool status)
    {
        foreach (var item in threeDObjButtons)
        {
            item.gameObject.GetComponent<BoxCollider>().enabled = status;
        }
    }

    private void ClickedOnCard()
    {
        foreach (var item in threeDObjButtons)
        {
            item.OnClicked += SetRevalCard;
        }
    }
    private void SetRevalCard(GameObject obj)
    {
        managerHandler.uIInputHandlerManager.cardShuffel_.ForEach((x) => { x.SetActive(false); });
        cardReveal.transform.position = obj.transform.position;
        cardReveal.gameObject.transform.parent.gameObject.SetActive(true);
    }

    public void ShowPopup(float delay, string msg)
    {
        GameObject obj = Instantiate(PopupPrefab);
        obj.GetComponent<PopupController>().msgToDisplay.text = msg;
        StartCoroutine(ShowPopupHelper(obj));
    }

    private IEnumerator ShowPopupHelper(GameObject obj)
    {
        yield return null;
        obj.GetComponent<PopupController>().popUpImage.DOScale(1, 0.5f);
        yield return new WaitForSeconds(1);
        obj.GetComponent<PopupController>().popUpImage.DOScale(0, 0.5f).OnComplete(()=> { Destroy(obj); });
    }
}
