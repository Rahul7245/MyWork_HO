using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShootState
{
    None=0,
    Start,
    PlayerTurn,
    SwitchCamera,
    StartShooting,
    Shooting,
    Shoot_Complete
}
public class ShootSceneStateManager : MonoBehaviour
{
    public static ShootSceneStateManager Instance { get; protected set; }
    private ShootState m_currentState;
    ShootSceneScript shootSceneScript;
    BirdViewSceneScript birdViewSceneScript;

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        shootSceneScript = gameObject.GetComponent<ShootSceneScript>();
        birdViewSceneScript = gameObject.GetComponent<BirdViewSceneScript>();
    }
   
    void Start()
    {
        ShootSceneStateManager.Instance.ToggleAppState(ShootState.Start);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public ShootState getCurrentShootstate {
        get
        {
            return m_currentState;
        }

    }
    public void ToggleAppState(ShootState appState)
    {
        if (m_currentState == appState)
        {
            return;
        }
        if (appState.Equals(ShootState.Start)) {
            m_currentState = appState;
            birdViewSceneScript.GenerateTracks();
            birdViewSceneScript.PlayerTurnTimer();
        }
        if (appState.Equals(ShootState.SwitchCamera))
        {
            m_currentState = appState;
            birdViewSceneScript.SwitchScene();
            ToggleAppState(ShootState.StartShooting);
        }
        // if have old state first exit then enter bew state
        if (appState.Equals(ShootState.StartShooting)) {
            m_currentState = appState;
            shootSceneScript.InitializeScene();
            ToggleAppState(ShootState.Shooting);
            return;
        }
        else if (appState.Equals(ShootState.Shooting))
        {
                 m_currentState = appState;
            gameObject.GetComponent<Timer>().startTimer();
        }
        else if (appState.Equals(ShootState.Shoot_Complete))
        {
            m_currentState = appState;
            gameObject.GetComponent<Timer>().stopTimer();
            shootSceneScript.AddShotEffects();
            shootSceneScript.CameraEffect();
            shootSceneScript.LoadScene();



        }
    }
}
