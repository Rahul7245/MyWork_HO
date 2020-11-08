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

    public override IEnumerator OnEnter()
    {
        yield return managerHandler.GetComponent<MonoBehaviour>().StartCoroutine(base.OnEnter());
        managerHandler.introCanvasHandler.StartLoadingBar();
    }
}
