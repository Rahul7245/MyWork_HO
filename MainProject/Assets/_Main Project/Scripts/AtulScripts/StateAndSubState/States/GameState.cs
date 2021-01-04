using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : State
{
    public override void OnEnter()
    {
        base.OnEnter();
        managerHandler.shootSceneStateManager.StartGame();
    }
}
