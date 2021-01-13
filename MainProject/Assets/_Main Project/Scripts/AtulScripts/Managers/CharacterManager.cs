using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        GameObject playerObj = managerHandler.
            uIInputHandlerManager.
            charactersPrefabsList[PlayerPrefManager.
            GetPlayerPrefInt(PlayerPrefKeys.CharacterSeleted_INT, 0)];
        if(playerObj == null)
            playerObj = managerHandler.uIInputHandlerManager.charactersPrefabsList[0];
        playerObj.GetComponent<Player>().PlayerName = 
            PlayerPrefManager.GetPlayerPrefString(PlayerPrefKeys.LocalPlayerName_STR, "Rohit");
        playerObj.GetComponent<Player>().playerType = PlayerType.Human;
        playerObj.GetComponent<Player>().charactersProperty = 
            managerHandler.uIInputHandlerManager.currentPlayingChar;
        managerHandler.gameInitManager.player[0] = playerObj;
        managerHandler.uIInputHandlerManager.
            OpenCharaSelectionButton.GetComponent<Image>().sprite = 
            managerHandler.uIInputHandlerManager.
            charatersSprites[PlayerPrefManager.
            GetPlayerPrefInt(PlayerPrefKeys.CharacterSeleted_INT, 0)];
        playerObj.GetComponent<Player>().charactersProperty = 
            managerHandler.uIInputHandlerManager.currentPlayingChar;
        playerObj.GetComponent<Player>().charactersProperty.
            SetDeafult(managerHandler.uIInputHandlerManager.
            PlayersPlayingImages
            [PlayerPrefManager.GetPlayerPrefInt(PlayerPrefKeys.CharacterSeleted_INT, 0)],
            playerObj.GetComponent<Player>().PlayerName,
            playerObj.GetComponent<Player>().PlayerScore.ToString());
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
        switch (index)
        {
            case 0:
                managerHandler.uIInputHandlerManager.characterDiscription.text = Constants.Msg_Char00_Dis;
                break;
            case 1:
                managerHandler.uIInputHandlerManager.characterDiscription.text = Constants.Msg_Char01_Dis;
                break;
            case 2:
                managerHandler.uIInputHandlerManager.characterDiscription.text = Constants.Msg_Char02_Dis;
                break;
            case 3:
                managerHandler.uIInputHandlerManager.characterDiscription.text = Constants.Msg_Char03_Dis;
                break;
            case 4:
                managerHandler.uIInputHandlerManager.characterDiscription.text = Constants.Msg_Char04_Dis;
                break;
            case 5:
                managerHandler.uIInputHandlerManager.characterDiscription.text = Constants.Msg_Char05_Dis;
                break;
        }
    }

    public void GamePlayingType(GameType gameType)
    {
        switch (gameType)
        {
            case GameType.VSComputer:
                managerHandler.gameInitManager.SetGameType(GameType.VSComputer);
                managerHandler.uIInputHandlerManager.cardShuffel_.ForEach((x) => { x.SetActive(false); });
                managerHandler.uIInputHandlerManager.cardShuffel_[0].SetActive(true);
                managerHandler.gameInitManager.player[0].GetComponent<CharacterCustomiser>().capMat.color = Color.red;
                managerHandler.gameInitManager.player[1].GetComponent<CharacterCustomiser>().capMat.color = Color.white;
                break;
            case GameType.VSFriend:
                managerHandler.gameInitManager.SetGameType(GameType.VSFriend);
                managerHandler.uIInputHandlerManager.cardShuffel_.ForEach((x) => { x.SetActive(false); });
                break;
        }
    }
}
