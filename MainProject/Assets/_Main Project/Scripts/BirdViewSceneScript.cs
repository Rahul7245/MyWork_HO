using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class BirdViewSceneScript : MonoBehaviour
{
    [SerializeField]
    private ManagerHandler managerHandler;
    public GameObject readyPlayerPopUp;
    ResetWeapon resetWeapon = new ResetWeapon();

    
    void Start()
    {
        EventManager.AddReloadWeaponInvoker(this);
    }
    public void AddResetWeaponListener(UnityAction listener)
    {

        resetWeapon.AddListener(listener);
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void GenerateTracks()
    {
        managerHandler.gameInitManager.InstantiateTrack();
        managerHandler.gameInitManager.InstantiatePlayers();
        managerHandler.gameInitManager.startTour();
    }
    public void endTour()
    {
        managerHandler.gameInitManager.endTour();
    }
    public void PlayerTurnTimer()
    {
        StartCoroutine(ResetPopUp());

    }
    IEnumerator ResetPopUp()
    {

        readyPlayerPopUp.SetActive(true);
        yield return new WaitForSeconds(3);
        readyPlayerPopUp.GetComponentInChildren<TextMeshProUGUI>().text = "3";
        readyPlayerPopUp.SetActive(false);
        ShootSceneStateManager.Instance.ToggleAppState(ShootState.SwitchCamera);

    }
    public void SetReadyPopUpText(string msg, bool forceToShowPopup = false)
    {
        if (forceToShowPopup)
        {
            readyPlayerPopUp.GetComponentInChildren<TextMeshProUGUI>().text = "";
            readyPlayerPopUp.SetActive(true);
        }
        readyPlayerPopUp.GetComponentsInChildren<TextMeshProUGUI>()[1].text = msg;
    }
    public void SwitchScene()
    {
        gameObject.GetComponent<SwitchCamera>().ShootCameraEnable(true);
        resetWeapon.Invoke();
    }

    public void MovePlayer(int noOfSteps)
    {
      bool shouldMove=  managerHandler.gameInitManager.GetPlayer(managerHandler.shootSceneStateManager.playerGettingAffected)
               .GetComponent<Player>().AddToScore(managerHandler.shootSceneStateManager.isforward ? PlayerPrefs.GetInt("Score") : (0 - PlayerPrefs.GetInt("Score")));
        if (shouldMove) {
            managerHandler.gameInitManager.movePlayer(managerHandler.shootSceneStateManager.playerGettingAffected,
            noOfSteps, managerHandler.shootSceneStateManager.isforward);
        }
        else {
            managerHandler.shootSceneStateManager.setNextTurnFlag(true);
        }
    }
    public void SetCameraToCurrentPlayer()
    {
        managerHandler.gameInitManager.setCameraToNormal(PlayerPrefs.GetInt("Turn"));
    }
}
