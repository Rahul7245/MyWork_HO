using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : State
{
    public override IEnumerator OnEnter()
    {
        yield return managerHandler.GetComponent<MonoBehaviour>().StartCoroutine(base.OnEnter());
        managerHandler.shootSceneStateManager.StartGame();
    }
}
