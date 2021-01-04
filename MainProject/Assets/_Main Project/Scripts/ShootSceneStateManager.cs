﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

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
    [SerializeField]
    private ManagerHandler managerHandler;
    public TextMeshProUGUI displayMsg;
    public static ShootSceneStateManager Instance { get; protected set; }
    private bool m_readyFornextTurn;
    private ShootState m_currentState;
    int totalPlayer = 2;
    GameObject playerPlaying = null;
    Player player = null;
    int EnvironmentNum = -1;
    public GameObject ConfettiCelebration;
    public GameObject ConfettiCelebrationCamera;
    List<int> playerLoosingChance;
    public bool playerGettingChance;
    public int playerGettingAffected;
    public bool isforward;

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        playerLoosingChance = new List<int>();
        playerGettingChance = false;
        playerGettingAffected = 0;
    }

    public void StartGame()
    {
        ToggleAppState(ShootState.Start);
    }

    // Update is called once per frame

    public ShootState getCurrentShootstate
    {
        get
        {
            return m_currentState;
        }

    }
    public void AfterTour()
    {
        managerHandler.birdViewSceneScript.endTour();
        ToggleAppState(ShootState.PlayerTurn);
    }
    public void ToggleAppState(ShootState appState)
    {
        if (m_currentState == appState)
        {
            if (m_currentState != ShootState.PlayerTurn)
                return;
        }
        if (appState.Equals(ShootState.Start))
        {
            displayMsg.text = "";
            m_currentState = appState;
            managerHandler.birdViewSceneScript.GenerateTracks();
            if (PlayerPrefs.HasKey("Turn"))
            {
                PlayerPrefs.DeleteKey("Turn");

            }
            PlayerPrefs.SetInt("Turn", 0);
            Weapon.points.Clear();

        }
        if (appState.Equals(ShootState.PlayerTurn))
        {
            m_readyFornextTurn = false;
            m_currentState = appState;
            if (PlayerPrefs.HasKey("Turn"))
            {
                int turn = PlayerPrefs.GetInt("Turn");
                if (!playerGettingChance)
                {
                    PlayerPrefs.DeleteKey("Turn");
                    PlayerPrefs.SetInt("Turn", (turn + 1) > totalPlayer ? 1 : (turn + 1));
                    isforward = true;
                    playerGettingAffected = PlayerPrefs.GetInt("Turn");
                    playerPlaying = managerHandler.gameInitManager.GetPlayer(PlayerPrefs.GetInt("Turn"));
                    player = playerPlaying?.GetComponent<Player>();
                    if (player.GetSkip())
                    {
                        player.SetSkip(false);
                        ToggleAppState(ShootState.PlayerTurn);
                        return;
                    }
                }
                else
                {
                    playerGettingChance = false;
                }
            }
            managerHandler.birdViewSceneScript.SetCameraToCurrentPlayer();
            displayMsg.text = player.playerName + "`s Turn";
            managerHandler.birdViewSceneScript.SetReadyPopUpText(player.playerName + "`s Turn");
            managerHandler.birdViewSceneScript.PlayerTurnTimer();
        }

        if (appState.Equals(ShootState.SwitchCamera))
        {
            managerHandler.shootSceneScript.PointsCanvas.SetActive(false);
            m_currentState = appState;
            if (player != null)
            {
                if (player.playerType == PlayerType.Computer)
                {
                    displayMsg.text = player.playerName + " is Playing";
                    ToggleAppState(ShootState.StartShooting);
                }
                else
                {
                    managerHandler.appStateManager.ToggleApp(AppState.GameScreen, AppSubState.GameScreen_ShootingMode, StartShooting, true);
                }
            }
        }
        // if have old state first exit then enter bew state
        if (appState.Equals(ShootState.StartShooting))
        {
            m_currentState = appState;
            if (player.playerType == PlayerType.Human)
            {
                int x = UnityEngine.Random.Range(0, 5);
                if (EnvironmentNum == x)
                {
                    x = UnityEngine.Random.Range(1, 4);
                    EnvironmentNum += x;
                }
                else
                {
                    EnvironmentNum = x;
                }

                if (EnvironmentNum > 4)
                {
                    EnvironmentNum = 0;
                }
                StartCoroutine(managerHandler.shootSceneScript.InitializeScene(EnvironmentNum, () => { ToggleAppState(ShootState.Shooting); }));
            }
            else
            {
                ToggleAppState(ShootState.Shooting);
            }
        }
        else if (appState.Equals(ShootState.Shooting))
        {
            m_currentState = appState;
            if (player.playerType == PlayerType.Human)
            {
                managerHandler.timer.totalTime = 10;
                managerHandler.timer.startTimer();
                managerHandler.audioManager.PlayAudio(AudioSourceType.ANIMEF, AudioCLips.AC_Timmer, false);
            }
            else
            {
                managerHandler.timer.totalTime = UnityEngine.Random.Range(2, 5);
                managerHandler.timer.startTimer();
            }

        }
        else if (appState.Equals(ShootState.Shoot_Complete))
        {
            m_currentState = appState;
            managerHandler.timer.stopTimer();
            if (player.playerType == PlayerType.Computer)
            {
                int computerScore = ShootingBot.BotPlay(Weapon.points.ToArray(), player.PlayerScore);
                PlayerPrefs.SetInt("Score", computerScore);
            }

            player.LastPointScored = PlayerPrefs.GetInt("Score");
            if (PlayerPrefs.GetInt("Score") > 0)
            {
                managerHandler.shootSceneScript.AddShotEffects();
            }
            managerHandler.shootSceneScript.CameraEffect(player.playerName + " Shot " + player.LastPointScored);
            managerHandler.shootSceneScript.LoadScene();
        }
        else if (appState.Equals(ShootState.Result))
        {
            if (player.LastPointScored != 0)
            {
                managerHandler.birdViewSceneScript.MovePlayer(PlayerPrefs.GetInt("Score"));
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
            managerHandler.shootSceneScript.setBurglerNoneAnimation();
            displayMsg.text = "";
            StartCoroutine(WaitTillTurnOver());
        }
    }

    private void StartShooting()
    {
        managerHandler.birdViewSceneScript.SwitchScene();
        ToggleAppState(ShootState.StartShooting);
    }

    IEnumerator WaitTillTurnOver()
    {
        yield return new WaitUntil(() => m_readyFornextTurn == true);

        // check for any winner before other player start playing
        Player winner = null;
        bool winnerResult = managerHandler.gameInitManager.CheckForWinner(out winner);
        if (winnerResult)
        {
            displayMsg.text = winner.playerName + " is the winner !!!";
            winner.GetComponent<Animator>().SetBool("win", true);
            ConfettiCelebration.SetActive(true);
            managerHandler.audioManager.PlayAudio(AudioSourceType.ANIMEF, AudioCLips.AC_Win, false);
            CMCscript cmcs = ConfettiCelebrationCamera.GetComponent<CMCscript>();
            cmcs.SetLookAtProperty(winner);
            cmcs.StartRevolution();
            ConfettiCelebrationCamera.SetActive(true);

            yield return new WaitForSecondsRealtime(25f);
            cmcs.StopRevolution();
            ConfettiCelebration.SetActive(false);
            winner.GetComponent<Animator>().SetBool("win", false);
            managerHandler.gameInitManager.ResetGame();
            ConfettiCelebrationCamera.SetActive(false);

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
