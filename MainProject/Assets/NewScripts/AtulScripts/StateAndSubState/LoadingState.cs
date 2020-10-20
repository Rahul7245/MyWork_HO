using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingState : State
{
    private void Awake()
    {
        appState = AppState.LoadingScreen;
    }

    public override void OnEnter()
    {
        CurrentScreenGameObject.SetActive(true);
        base.OnEnter();
        currentCanvasGrup.alpha = 1;
        managerHandler.introCanvasHandler.StartLoadingBar();
    }
    public override void OnExit()
    {
        base.OnExit();
        currentCanvasGrup.alpha = 0;
        CurrentScreenGameObject.SetActive(false);
    }
}
