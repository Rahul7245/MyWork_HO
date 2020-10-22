using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingState : State
{
    protected override void Awake()
    {
        base.Awake();
        appState = AppState.LoadingScreen;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        managerHandler.introCanvasHandler.StartLoadingBar();
    }
    public override void OnExit()
    {
        base.OnExit();
    }
}
