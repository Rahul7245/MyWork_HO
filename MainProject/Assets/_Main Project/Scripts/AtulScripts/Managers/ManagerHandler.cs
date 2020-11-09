using System.Collections;
using System.Collections.Generic;
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
    public SpawnEnemy spawnEnemy;
    public SwitchCamera switchCamera;

    private void Awake()
    {
        managerHandler = this;
    }
}
