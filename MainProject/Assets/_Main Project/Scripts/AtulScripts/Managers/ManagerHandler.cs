﻿using GammaXR.TransistionEffect;
using UnityEngine;

public class ManagerHandler : MonoBehaviour
{
    public static ManagerHandler managerHandler;
    public IntroCanvasHandler introCanvasHandler;
    public AppStateManager appStateManager;
    public UIInputHandlerManager uIInputHandlerManager;
    public ShootSceneStateManager shootSceneStateManager;
    public LightingManager lightingManager;
    public GameInitManager gameInitManager;
    public SwitchCamera switchCamera;
    public ShootSceneScript shootSceneScript;
    public Timer timer;
    public BirdViewSceneScript birdViewSceneScript;
    public CharacterManager characterManager;
    public LoginManager loginManager;
    public HomeScreenManager homeScreenManager;
    public AllEffects allEffects;
    public AudioManager audioManager;
    public VideoTransistionManager videoTransistionManager;
    public Controller controller;

    private void Awake()
    {
        managerHandler = this;
    }
}
