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
    Shoot_Complete,
    Result
}
public class ShootSceneStateManager : MonoBehaviour
{
    public GameObject SceneManager;
    public static ShootSceneStateManager Instance { get; protected set; }
    private ShootState m_currentState;
    ShootSceneScript shootSceneScript;
    BirdViewSceneScript birdViewSceneScript;

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        shootSceneScript = SceneManager.GetComponent<ShootSceneScript>();
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
            ToggleAppState(ShootState.PlayerTurn);
        }
        if (appState.Equals(ShootState.PlayerTurn))
        {
            m_currentState = appState;
      
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
            SceneManager.GetComponent<Timer>().startTimer();
        }
        else if (appState.Equals(ShootState.Shoot_Complete))
        {
            m_currentState = appState;
            SceneManager.GetComponent<Timer>().stopTimer();
            if (PlayerPrefs.GetInt("Score") > 0) { shootSceneScript.AddShotEffects(); }
            
            shootSceneScript.CameraEffect();
            shootSceneScript.LoadScene();



        }

        else if (appState.Equals(ShootState.Result))
        {
            m_currentState = appState;
            VigneteEffect.Instance.ResetVignete();
            shootSceneScript.setBurglerNoneAnimation();

            ToggleAppState(ShootState.PlayerTurn);
        }
    }
}
