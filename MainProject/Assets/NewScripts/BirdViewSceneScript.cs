using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class BirdViewSceneScript : MonoBehaviour
{
    TrackSpawner trackSpawner;
    public GameObject readyPlayerPopUp;
    ResetWeapon resetWeapon = new ResetWeapon();

    // Start is called before the first frame update
    private void Awake()
    {
        
       trackSpawner= gameObject.GetComponent<TrackSpawner>();
    }
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
    public void GenerateTracks() {
        trackSpawner.InstantiateTrack();
        trackSpawner.InstantiatePlayers();
    }

    public void PlayerTurnTimer() {
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
    public void SetReadyPopUpText(string msg, bool forceToShowPopup = false) {
        if (forceToShowPopup)
        {
            readyPlayerPopUp.GetComponentInChildren<TextMeshProUGUI>().text = "";
            readyPlayerPopUp.SetActive(true);
        }
        readyPlayerPopUp.GetComponentsInChildren<TextMeshProUGUI>()[1].text = msg;
    }
    public void SwitchScene() {
        gameObject.GetComponent<SwitchCamera>().ShootCameraEnable(true);
        resetWeapon.Invoke();

    }

    public void MovePlayer(int noOfSteps) {
        trackSpawner.movePlayer(PlayerPrefs.GetInt("Turn"), noOfSteps, true);
    }
    public void SetCameraToCurrentPlayer()
    {
        trackSpawner.setCameraToNormal(PlayerPrefs.GetInt("Turn"));
    }
}
