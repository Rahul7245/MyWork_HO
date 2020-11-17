﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    private ManagerHandler managerHandler;

    private void Awake()
    {
        if (PlayerPrefManager.HasKey(PlayerPrefKeys.CharacterSeleted_INT))
        {
            CharaterClickUIEffet(PlayerPrefManager.GetPlayerPrefInt(PlayerPrefKeys.CharacterSeleted_INT, 0));
        }
        else
        {
            CharaterClickUIEffet(0);
        }
        SelectCharaterForGame();
    }

    public void SelectCharaterForGame()
    {
        managerHandler.gameInitManager.player[0] = managerHandler.uIInputHandlerManager.charactersPrefabsList[PlayerPrefManager.GetPlayerPrefInt(PlayerPrefKeys.CharacterSeleted_INT, 0)];
    }

    public void CharacterButtonClicked(int index)
    {
        CharaterClickUIEffet(index);
    }

    private void CharaterClickUIEffet(int index)
    {
        foreach (var item in managerHandler.uIInputHandlerManager.CharacterImages)
        {
            item.SetActive(false);
        }
        foreach (var item in managerHandler.uIInputHandlerManager.CharacterModels)
        {
            item.SetActive(false);
        }
        managerHandler.uIInputHandlerManager.CharacterImages[index].SetActive(true);
        managerHandler.uIInputHandlerManager.CharacterModels[index].SetActive(true);
        PlayerPrefManager.SetPlayerPref(PlayerPrefKeys.CharacterSeleted_INT, index);
    }
}
