﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;
using Cinemachine;
using TMPro;
using System.Linq;
using UnityEngine.Playables;

public enum GameType
{
    VSComputer,
    VSFriend,
    VSOnline
}

public enum HurdleType
{

}

public class Hurdle
{
    public int pos, power;
}

public class GameInitManager : MonoBehaviour
{
    [SerializeField]
    private ManagerHandler managerHandler;
    // type of game user is playing
    private GameType gameType;
    public AnimationCurve curve;
    public GameObject startPoint;
    public GameObject trackCube;
    public GameObject powerCube;
    public GameObject hurdleCube;
    public GameObject track;
    public GameObject[] player;
    public int no_of_hurdles;
    public Canvas Ready_popup;
    public GameObject[] playerPositionCanvas;
    public GameObject currentPlayerCanvas;
    // Start is called before the first frame update
    Dictionary<string, GameObject[]> m_tracks = new Dictionary<string, GameObject[]>();
    Dictionary<string, GameObject> m_players = new Dictionary<string, GameObject>();
    Dictionary<string, int> m_player_pos = new Dictionary<string, int>();
    Dictionary<string, Hurdle[]> m_player_pow = new Dictionary<string, Hurdle[]>();
    int m_turn;
    bool m_ready, m_askingPlayer;

    ResetWeapon resetWeapon = new ResetWeapon();
    float trackDistance = 8f;
    float characterYaxisOffset = 0.0f;
    public CinemachineVirtualCamera vcam;
    public CinemachineVirtualCamera sideVcam;
    public CinemachineVirtualCamera startCam;
    CinemachineTrackedDolly m_dollyCam;
    PlayableDirector m_director;
    int hurdleNumber ;
    public void SetGameType(GameType gameType)
    {
        this.gameType = gameType;
        switch (gameType)
        {
            case GameType.VSComputer:
                int randomPlayer = Random.Range(0, 6);
                if(PlayerPrefManager.GetPlayerPrefInt(PlayerPrefKeys.CharacterSeleted_INT, 0) == randomPlayer)
                {
                    randomPlayer += 1;
                    if(randomPlayer > 5)
                    {
                        randomPlayer = 0;
                    }
                }
                GameObject playerObj = managerHandler.uIInputHandlerManager.charactersPrefabsList[randomPlayer];
                playerObj.GetComponent<Player>().playerName = "Bot";
                playerObj.GetComponent<Player>().playerType = PlayerType.Computer;
                player[1] = playerObj;
                break;
        }
    }
    bool tourStarted=false;
    public void startTour() {
        startCam.gameObject.SetActive(true);
        startCam.Priority = 12;
        tourStarted = true;
    }
    public void endTour()
    {
       // startCam.gameObject.SetActive(true);
        startCam.Priority = 8;
        tourStarted = false;
        if (hurdlesGroup.Count <= 0) { return; }
        foreach (var hurdle in hurdlesGroup) {
            hurdle.SetActive(false);
        }
        hurdlesGroup.Clear();
    }
    public static int NoOfPlayerNeeded(GameType gameType)
    {
        switch (gameType)
        {
            case GameType.VSComputer:
                return 2;
            default:
                return 2;
        }

    }

    void Start()
    {
        /*InstantiateTrack();
        InstantiatePlayers();*/

        m_turn = 1;
        m_ready = true;
        //askingPlayer = true;
        //Ready_popup.GetComponentInChildren<Text>().text = "Are you Ready Player_"+turn;
        //   StartCoroutine(StartGame());
        EventManager.AddShootListener(movePlayerListener);

        foreach (var playerPosCan in playerPositionCanvas)
        {
            playerPosCan.GetComponentInChildren<TextMeshProUGUI>().text = "0";
        }
        m_dollyCam = startCam.GetCinemachineComponent<CinemachineTrackedDolly>();
        
        m_director = startCam.GetComponent<PlayableDirector>();
        hurdleNumber = no_of_hurdles;
    }
    public void AddResetWeaponListener(UnityAction listener)
    {

        resetWeapon.AddListener(listener);
    }
    public void InstantiatePlayers()
    {
        for (int i = 1; i <= NoOfPlayerNeeded(gameType); i++)
        {
            GameObject[] obj = null;
            if (m_tracks.TryGetValue("player_" + i + "_Track", out obj))
            {
                GameObject pl = Instantiate(player[i - 1], obj[0].transform.position + new Vector3(0, characterYaxisOffset, 0), Quaternion.identity);
                pl.name = "player_" + i;
                m_players.Add("player_" + i, pl);
                m_player_pos.Add("player_" + i, 0);

            }
        }


    }
    Hurdle[] sortedHurdles;
    public void InstantiateTrack()
    {
        sortedHurdles = RandomPowerPosition(0);
        for (int j = 1; j <= NoOfPlayerNeeded(gameType); j++)
        {
            GameObject[] playerTrackArr = new GameObject[22];
            GameObject playerTrack = new GameObject("player_" + j + "_Track");
            Vector3 pos = new Vector3(10, 0, 0);
            GameObject st = Instantiate(startPoint, pos + new Vector3(j * 5 + 3, 0, 0), Quaternion.identity);
            pos = st.transform.position;
            st.transform.parent = playerTrack.transform;
            st.name = "start_pos_" + j;
            playerTrackArr[0] = st;
            for (int i = 1; i <= 21; i++)
            {
                GameObject tc = Instantiate(trackCube, pos + new Vector3(0, 0, i * trackDistance), Quaternion.identity);
                tc.transform.parent = playerTrack.transform;
                tc.name = "block_" + i;
                playerTrackArr[i] = tc;
            }
            foreach (var hurdle in sortedHurdles)
            {
                GameObject tc = null;
                if (hurdle.power % 2 == 1)
                {
                    tc = Instantiate(powerCube, pos + new Vector3(0, 0, hurdle.pos * trackDistance), Quaternion.identity);
                }
                else if (hurdle.power % 2 == 0)
                {
                    tc = Instantiate(hurdleCube, pos + new Vector3(0, 0, hurdle.pos * trackDistance), Quaternion.identity);
                }
                if (tc)
                {
                    Destroy(playerTrackArr[hurdle.pos]);
                    tc.transform.parent = playerTrack.transform;
                    tc.name = "block_" + hurdle.pos;
                    playerTrackArr[hurdle.pos] = tc;
                    tc.SetActive(false);

                }

            }
            playerTrack.transform.SetParent(track.transform);

            m_tracks.Add("player_" + j + "_Track", playerTrackArr);
        }

    }
    Hurdle[] RandomPowerPosition(int playerNumber)
    {
        Hurdle[] hurdles = new Hurdle[no_of_hurdles];

        for (int i = 1; i <= no_of_hurdles; i++)
        {
            if (i == 1)
            {
                Hurdle hurdle = new Hurdle();
                hurdle.pos = UnityEngine.Random.Range(2, 20);
                hurdle.power = UnityEngine.Random.Range(1, 6);
                hurdles[i - 1] = hurdle;
            }
            else
            {
                Hurdle hurdle = new Hurdle();
                hurdle.pos = UnityEngine.Random.Range(2, 20);
                Loopback: while (true)
                {
                    for (int j = 0; j < i - 1; j++)
                    {
                        if (Mathf.Abs(hurdle.pos - hurdles[j].pos) < 3)
                        {
                            hurdle.pos = UnityEngine.Random.Range(2, 20);
                            goto Loopback;
                        }
                    }
                    break;
                }

                hurdle.power = UnityEngine.Random.Range(1, 6);

                hurdles[i - 1] = hurdle;

            }

        }
        Hurdle[] sorted = hurdles.OrderBy(c => c.pos).ToArray();
        m_player_pow.Add("player_" + playerNumber + "_pow", sorted);
        return sorted;

    }
    /*Hurdle[] ArrangeInDecendingPosition(Hurdle[] hurdles) {
        Hurdle[] ret=new Hurdle[no_of_hurdles];

        Hurdle[] sorted = hurdles.OrderBy(c => c.pos).ToArray();



        return sorted;

    }*/

    IEnumerator StartGame()
    {
        GameObject current_Player;
        m_players.TryGetValue("player_" + m_turn, out current_Player);
        vcam.m_LookAt = current_Player.transform;
        vcam.m_Follow = current_Player.transform;
        sideVcam.m_Priority = 9;
        sideVcam.m_LookAt = current_Player.transform;
        sideVcam.m_Follow = current_Player.transform;
        Ready_popup.GetComponentInChildren<TextMeshProUGUI>().text = "Are you Ready Player_" + m_turn;
        Ready_popup.gameObject.SetActive(true);
        m_askingPlayer = true;
        yield return new WaitForSeconds(3.5f);
        ReadyButtonPressed();
    }

    void movePlayerListener(int stepsToMove)
    {
        print("movePlayerListener");
        if (!m_ready)
        {
            return;
        }
        m_ready = false;
        m_askingPlayer = false;
        Debug.Log("!@# TrackSpwaner movePlayerListener called with steps : " + stepsToMove);
        movePlayer(m_turn, stepsToMove, true);
        sideVcam.m_Priority = 11;
        //  CheckForHurdle(turn,pos);
        m_turn += 1;
        if (m_turn > NoOfPlayerNeeded(gameType))
        {
            m_turn = 1;
        }

    }
    void CheckForHurdle(int playerNumber, int currentPosition)
    {
        Hurdle[] hurdles;
        bool hurdleFound = false;
        m_player_pow.TryGetValue("player_0"/* + playerNumber*/ + "_pow", out hurdles);
        Player _currentPlayer = GetPlayer().GetComponent<Player>();
        foreach (var hurdle in hurdles)
        {
            if (currentPosition == hurdle.pos)
            {
                hurdleFound = true;
                if (hurdle.power == 2 || hurdle.power == 4 || hurdle.power == 6)
                {
                    _currentPlayer.LastPointScored = -2;
                    _currentPlayer.AddToScore(-2);
                    movePlayer(playerNumber, -2, false);
                    return;
                }
                else if (hurdle.power == 1 || hurdle.power == 3 || hurdle.power == 5)
                {
                    _currentPlayer.LastPointScored = 2;
                    _currentPlayer.AddToScore(2);
                    movePlayer(playerNumber, 2, true);
                    return;
                }
            }
        }
        if (!hurdleFound)
        {
            ShootSceneStateManager.Instance.setNextTurnFlag(true);
        }
        m_ready = true;

    }

    public void setCameraToNormal(int turn)
    {
        GameObject current_Player;
        m_players.TryGetValue("player_" + turn, out current_Player);
        vcam.m_LookAt = current_Player.transform;
        vcam.m_Follow = current_Player.transform;
        sideVcam.m_Priority = 9;
        sideVcam.m_LookAt = current_Player.transform;
        sideVcam.m_Follow = current_Player.transform;

    }
    public int movePlayer(int playerNumber, int steps, bool movingForward)
    {
        sideVcam.m_Priority = 11;
        GameObject current_Player;
        m_players.TryGetValue("player_" + playerNumber, out current_Player);
        int pos;
        m_player_pos.TryGetValue("player_" + playerNumber, out pos);
        pos += steps;
        playerPositionCanvas[playerNumber - 1].GetComponentInChildren<TextMeshProUGUI>().text = pos.ToString();
        currentPlayerCanvas.GetComponentInChildren<Image>().sprite = playerPositionCanvas[playerNumber - 1].GetComponentInChildren<Image>().sprite;
        currentPlayerCanvas.GetComponentInChildren<TextMeshProUGUI>().text = pos.ToString();
        GameObject[] track;
        m_tracks.TryGetValue("player_" + playerNumber + "_Track", out track);
        if (movingForward)
        {

            current_Player.transform.GetComponent<Rigidbody>().DOMove(
            track[pos].transform.position + new Vector3(0, characterYaxisOffset, 0), (float)steps * .7f + .8f).OnStart(() =>
               {
                   current_Player.GetComponent<Animator>().SetBool("jump", true);
                   current_Player.GetComponent<DustEffect>().PlayParticle();
               //     print("Animation started");
           }).OnComplete(() =>
           {
               current_Player.GetComponent<Animator>().SetBool("jump", false);
               current_Player.GetComponent<DustEffect>().StopParticle();

           }).SetEase(curve);
            StartCoroutine(animationtimer(playerNumber, pos, current_Player));
        }
        else
        {

            current_Player.transform.GetComponent<Rigidbody>().DOMove(
           track[pos].transform.position + new Vector3(0, characterYaxisOffset, 0), 3f).OnStart(() =>
           {
               current_Player.GetComponent<Animator>().SetBool("fall", true);
               print("Animation started");
           }).OnComplete(() =>
          {
              print("Animation ended");
              current_Player.GetComponent<Animator>().SetBool("fall", false);
              ShootSceneStateManager.Instance.setNextTurnFlag(true);
              m_ready = true;
          });

            // StartCoroutine( animationFall(track[pos].transform.position + new Vector3(0, characterYaxisOffset, 0), current_Player));
        }

        m_player_pos.Remove("player_" + playerNumber);
        m_player_pos.Add("player_" + playerNumber, pos);
        return pos;

    }

    IEnumerator animationtimer(int playerNumber, int currentPosition, GameObject current_Player)
    {
        yield return new WaitForSeconds(.5f);
        yield return new WaitWhile(() => current_Player.GetComponent<Animator>().GetBool("jump") == true);
        yield return new WaitForSeconds(1f);
        CheckForHurdle(playerNumber, currentPosition);

    }
    public void ReadyButtonPressed()
    {
        Ready_popup.gameObject.SetActive(false);
        gameObject.GetComponent<SwitchCamera>().ShootCameraEnable(true);
        Controller.Instance.DisplayCursor(false);
        resetWeapon.Invoke();

        // GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>().Reset();
    }
    public GameObject GetPlayer()
    {
        int playerIndex = PlayerPrefs.GetInt("Turn");
        GameObject player = null;
        m_players.TryGetValue("player_" + playerIndex, out player);
        return player;
    }

    public bool CheckForWinner(out Player player)
    {
        player = null;
        bool result = false;
        foreach (var item in m_players)
        {
            player = item.Value.GetComponent<Player>();
            if (player.PlayerScore >= 21)
            {
                result = true;
                break;
            }
        }

        return result;
    }
    List<GameObject> hurdlesGroup=new List<GameObject>();
    IEnumerator ShowHurdles(int hurdleNum) {
        m_director.Pause();
        
        Hurdle[] hurdles;
        m_player_pow.TryGetValue("player_0"/* + playerNumber*/ + "_pow", out hurdles);
       
        for (int i = 1; i <= 2; i++) {

            GameObject[] track;
            m_tracks.TryGetValue("player_" + i + "_Track", out track);
            GameObject h = track[hurdleNum];
            h.SetActive(true);
            hurdlesGroup.Add(h);
        }
        hurdleNumber -= 1;
        yield return new WaitForSeconds(2f);
        
        m_director.Play();



    }
    
    private void Update()
    {
        if (!tourStarted) {
            return;
        }
        if (hurdleNumber <= 0) {
            return;
        }
        if (m_dollyCam.m_PathPosition >= 4+20-sortedHurdles[hurdleNumber-1].pos)
        {
            StartCoroutine(ShowHurdles(sortedHurdles[hurdleNumber - 1].pos));
        }
    }
}
