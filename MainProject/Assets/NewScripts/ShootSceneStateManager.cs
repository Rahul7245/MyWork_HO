using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShootState
{
    None = 0,
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
    public TrackSpawner trackSpawner;
    public static ShootSceneStateManager Instance { get; protected set; }
    private bool m_readyFornextTurn;
    private ShootState m_currentState;
    ShootSceneScript shootSceneScript;
    BirdViewSceneScript birdViewSceneScript;
    int totalPlayer = 2;
    GameObject playerPlaying = null;
    Player player = null;

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

    public ShootState getCurrentShootstate
    {
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
        if (appState.Equals(ShootState.Start))
        {
            m_currentState = appState;
            birdViewSceneScript.GenerateTracks();
            if (PlayerPrefs.HasKey("Turn"))
            {
                PlayerPrefs.DeleteKey("Turn");

            }
            PlayerPrefs.SetInt("Turn", 0);
            Weapon.points.Clear();
            ToggleAppState(ShootState.PlayerTurn);
        }
        if (appState.Equals(ShootState.PlayerTurn))
        {
            m_readyFornextTurn = false;
            m_currentState = appState;
            if (PlayerPrefs.HasKey("Turn"))
            {
                int turn = PlayerPrefs.GetInt("Turn");
                PlayerPrefs.DeleteKey("Turn");
                PlayerPrefs.SetInt("Turn", (turn + 1) > totalPlayer ? 1 : (turn + 1));
            }
            playerPlaying = trackSpawner.GetPlayer();
            player = playerPlaying?.GetComponent<Player>();

            birdViewSceneScript.SetCameraToCurrentPlayer();
            birdViewSceneScript.SetReadyPopUpText(player.playerName+"`s Turn");
            birdViewSceneScript.PlayerTurnTimer();
        }

        if (appState.Equals(ShootState.SwitchCamera))
        {
            m_currentState = appState;
            if (player != null)
            {
                if(player.playerType == PlayerType.Computer)
                {
                    ToggleAppState(ShootState.StartShooting);
                }
                else
                {
                    birdViewSceneScript.SwitchScene();
                    ToggleAppState(ShootState.StartShooting);
                }
            }
            else
            {
                birdViewSceneScript.SwitchScene();
                ToggleAppState(ShootState.StartShooting);
            }
        }
        // if have old state first exit then enter bew state
        if (appState.Equals(ShootState.StartShooting))
        {
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
            if(player.playerType == PlayerType.Computer)
            {
                int computerScore = ShootingBot.BotPlay(Weapon.points.ToArray());
                PlayerPrefs.SetInt("Score", computerScore);
            }
            player.LastPointScored = PlayerPrefs.GetInt("Score");
            player.AddToScore(PlayerPrefs.GetInt("Score"));
            if (PlayerPrefs.GetInt("Score") > 0)
            {
                shootSceneScript.AddShotEffects();
            }

            shootSceneScript.CameraEffect();
            shootSceneScript.LoadScene();
        }

        else if (appState.Equals(ShootState.Result))
        {
            if (player.LastPointScored != 0)
            {
                birdViewSceneScript.MovePlayer(PlayerPrefs.GetInt("Score"));
            }
            else
            {
                setNextTurnFlag(true);
            }
            
            if (PlayerPrefs.HasKey("Score"))
            {
                PlayerPrefs.DeleteKey("Score");
                PlayerPrefs.SetInt("Score", 0);
            }

            m_currentState = appState;
            VigneteEffect.Instance.ResetVignete();
            shootSceneScript.setBurglerNoneAnimation();
            StartCoroutine(WaitTillTurnOver());


        }
    }

    IEnumerator WaitTillTurnOver()
    {
        yield return new WaitUntil(() => m_readyFornextTurn == true);

        // check for any winner before other player start playing
        Player winner = null;
        bool winnerResult = trackSpawner.CheckForWinner(out winner);
        if (winnerResult)
        {
            birdViewSceneScript.SetReadyPopUpText(winner.playerName + " is the winner !!!");
        }
        else
        {
            ToggleAppState(ShootState.PlayerTurn);
        }
    }
    public void setNextTurnFlag(bool flag)
    {
        m_readyFornextTurn = flag;
    }
}
