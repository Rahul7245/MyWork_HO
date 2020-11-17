using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    private ManagerHandler managerHandler;

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
    }
}
