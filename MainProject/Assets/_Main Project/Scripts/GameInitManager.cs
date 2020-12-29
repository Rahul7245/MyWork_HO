using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;
using Cinemachine;
using TMPro;
using System.Linq;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

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
    public GameObject powerPlusTwo;
    public GameObject hurdleMinusTwo;
    public GameObject hurdleSelfDestruct;
    public GameObject powerExtraChance;
    public GameObject hurdleSkip;
    public GameObject rivalSkip;
    public GameObject rivalKill;
    public GameObject rivalhelp;
    public GameObject rivalSendBack;
    public GameObject track;
    public GameObject[] player;
    public int no_of_hurdles;
    public Canvas Ready_popup;
    public GameObject[] playerPositionCanvas;
    public GameObject currentPlayerCanvas;
    public GameObject RivalPopup;
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
        m_turn = 1;
        m_ready = true;
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
        sortedHurdles = RandomPowerPosition2();
        for (int j = 1; j <= NoOfPlayerNeeded(gameType); j++)
        {
            GameObject[] playerTrackArr = new GameObject[23];
            GameObject playerTrack = new GameObject("player_" + j + "_Track");
            Vector3 pos = new Vector3(10, 0, 0);
            GameObject st = Instantiate(startPoint, pos + new Vector3(j * 5 + 3, 0, 0), Quaternion.identity);
            pos = st.transform.position;
            st.transform.parent = playerTrack.transform;
            st.name = "start_pos_" + j;
            playerTrackArr[0] = st;
            for (int i = 1; i <= 22; i++)
            {
                GameObject tc = Instantiate(trackCube, pos + new Vector3(0, 0, i * trackDistance), Quaternion.identity);
                tc.transform.parent = playerTrack.transform;
                tc.name = "block_" + i;
                playerTrackArr[i] = tc;
            }
            foreach (var hurdle in sortedHurdles)
            {
                GameObject tc = null;
                if(hurdle.power == 1)
                {
                    tc = Instantiate(powerPlusTwo, pos + new Vector3(0, 0, hurdle.pos * trackDistance), Quaternion.identity);
                }
                else if (hurdle.power == 3)
                {
                    tc = Instantiate(powerExtraChance, pos + new Vector3(0, 0, hurdle.pos * trackDistance), Quaternion.identity);
                }else if (hurdle.power == 4)
                {
                    tc = Instantiate(hurdleSelfDestruct, pos + new Vector3(0, 0, hurdle.pos * trackDistance), Quaternion.identity);
                }
                if (hurdle.power == 6)
                {
                    tc = Instantiate(hurdleSkip, pos + new Vector3(0, 0, hurdle.pos * trackDistance), Quaternion.identity);
                }
                else if (hurdle.power == 2)
                {
                    tc = Instantiate(hurdleMinusTwo, pos + new Vector3(0, 0, hurdle.pos * trackDistance), Quaternion.identity);
                }
                else if (hurdle.power == 5)
                {
                    tc = Instantiate(rivalSkip, pos + new Vector3(0, 0, hurdle.pos * trackDistance), Quaternion.identity);
                }
                else if (hurdle.power == 7)
                {
                    tc = Instantiate(rivalKill, pos + new Vector3(0, 0, hurdle.pos * trackDistance), Quaternion.identity);
                }
                else if (hurdle.power == 8)
                {
                    tc = Instantiate(rivalhelp, pos + new Vector3(0, 0, hurdle.pos * trackDistance), Quaternion.identity);
                }
                else if (hurdle.power == 9)
                {
                    tc = Instantiate(rivalSendBack, pos + new Vector3(0, 0, hurdle.pos * trackDistance), Quaternion.identity);

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
    Hurdle[] RandomPowerPosition2()
    {
        Hurdle[] hurdles = new Hurdle[6];
         List<int> hurdleList = new List<int>{ 3, 4, 5, 6, 7};
        List<int> hur = new List<int>() {1,2,8,9 };
        hurdleList.Add(hur[Random.Range(0,hur.Count)]);
        List<int> randomTracks = new List<int> {19, 12, 18, 2, 11, 17, 5, 7, 16, 10, 6, 15, 3, 9, 14, 8, 4, 13 };
        for (int i = 0; i < 6; i++) {
           int num = Random.Range(0, randomTracks.Count);
            Hurdle hurdle = new Hurdle();
            int hurdleNum= randomTracks[num];
            
            if (randomTracks.Contains(hurdleNum + 1))
            {
                randomTracks.Remove(hurdleNum + 1);
            }
            if (randomTracks.Contains(hurdleNum - 1))
            {
                randomTracks.Remove(hurdleNum - 1);
            }
            hurdle.pos = hurdleNum;
            randomTracks.Remove(hurdleNum);
            hurdle.power = hurdleList[i];
            hurdles[i] = hurdle;
        }
        Hurdle[] sorted = hurdles.OrderBy(c => c.pos).ToArray();
        m_player_pow.Add("player_" + "0" + "_pow", sorted);
        for (int i = 0; i < 6; i++)
        {
            print("pos:" + sorted[i].pos + "pow:" + sorted[i].power);
        }
        return sorted;


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
                hurdle.power = UnityEngine.Random.Range(1, 8);
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

                hurdle.power = UnityEngine.Random.Range(1, 8);

                hurdles[i - 1] = hurdle;

            }

        }
        Hurdle[] sorted = hurdles.OrderBy(c => c.pos).ToArray();
        m_player_pow.Add("player_" + playerNumber + "_pow", sorted);
        return sorted;

    }

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
        if (!m_ready)
        {
            return;
        }
        m_ready = false;
        m_askingPlayer = false;
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
        Player _currentPlayer = GetPlayer(playerNumber).GetComponent<Player>();
        foreach (var hurdle in hurdles)
        {
            if (currentPosition == hurdle.pos)
            {
                hurdleFound = true;
                if (hurdle.power == 2 )
                {
                    StartCoroutine(ShowHurdle(PlayerPrefs.GetInt("Turn"), hurdle.pos));
                    _currentPlayer.LastPointScored = -2;
                    _currentPlayer.AddToScore(-2);
                    movePlayer(playerNumber, 2, false);
                    managerHandler.audioManager.PlayAudio(AudioSourceType.ANIMEF, AudioCLips.AC_Hurdule_Self_sub2);
                    return;
                }
                else if (hurdle.power == 1 )
                {
                    StartCoroutine(ShowHurdle(PlayerPrefs.GetInt("Turn"), hurdle.pos));
                    _currentPlayer.LastPointScored = 2;
                    _currentPlayer.AddToScore(2);
                    movePlayer(playerNumber, 2, true);
                    managerHandler.audioManager.PlayAudio(AudioSourceType.ANIMEF, AudioCLips.AC_Hurdule_Self_add2);
                    return;
                }
                else if (hurdle.power == 4)
                {
                    StartCoroutine(ShowHurdle(PlayerPrefs.GetInt("Turn"), hurdle.pos));
                    StartCoroutine( PlaySelfDestruct(_currentPlayer, PlayerPrefs.GetInt("Turn")));
                    managerHandler.audioManager.PlayAudio(AudioSourceType.ANIMEF, AudioCLips.AC_Hurdule_Self_die);
                }
                else if (hurdle.power == 6)
                {
                    StartCoroutine(ShowHurdle(PlayerPrefs.GetInt("Turn"), hurdle.pos));
                    StartCoroutine(PlaySkipChance(_currentPlayer));
                    managerHandler.audioManager.PlayAudio(AudioSourceType.ANIMEF, AudioCLips.AC_Hurdule_Self_Skip);
                }
                else if (hurdle.power == 3) {
                    StartCoroutine(ShowHurdle(PlayerPrefs.GetInt("Turn"), hurdle.pos));
                    StartCoroutine(PlayGettingExtraChance(_currentPlayer));
                    managerHandler.audioManager.PlayAudio(AudioSourceType.ANIMEF, AudioCLips.AC_Hurdule_Self_life);
                }
                else if (hurdle.power == 5)
                {
                    StartCoroutine(ShowHurdle(PlayerPrefs.GetInt("Turn"), hurdle.pos));
                    setCameraToNormal(PlayerPrefs.GetInt("Turn") == 1 ? 2 : 1);
                    StartCoroutine(PlaySkipChance(GetOppPlayer().GetComponent<Player>()));
                    managerHandler.audioManager.PlayAudio(AudioSourceType.ANIMEF, AudioCLips.AC_Hurdule_Rival_skip);
                }
                else if (hurdle.power == 7)
                {
                    StartCoroutine(ShowHurdle(PlayerPrefs.GetInt("Turn"), hurdle.pos));
                    StartCoroutine( PlaySelfDestruct(GetOppPlayer().GetComponent<Player>(),
                        PlayerPrefs.GetInt("Turn") == 1 ? 2 : 1));
                    managerHandler.audioManager.PlayAudio(AudioSourceType.ANIMEF, AudioCLips.AC_Hurdule_Rival_die);
                }
                else if (hurdle.power == 8|| hurdle.power == 9)
                {
                    StartCoroutine(ShowHurdle(playerNumber, hurdle.pos));
                    ManagerHandler.managerHandler.shootSceneStateManager.playerGettingAffected = PlayerPrefs.GetInt("Turn") == 1 ? 2 : 1;
                    ManagerHandler.managerHandler.shootSceneStateManager.playerGettingChance = true;
                    if (hurdle.power == 9) {
                        ManagerHandler.managerHandler.shootSceneStateManager.isforward = false;
                        managerHandler.audioManager.PlayAudio(AudioSourceType.ANIMEF, AudioCLips.AC_Hurdule_Rival_Back);
                    }
                    else
                    {
                        managerHandler.audioManager.PlayAudio(AudioSourceType.ANIMEF, AudioCLips.AC_Hurdule_Rival_Help);
                    }
                    ShootSceneStateManager.Instance.setNextTurnFlag(true);
                }
            }
        }
        if (_currentPlayer.PlayerScore==21) {
            _currentPlayer.AddToScore(1);
            movePlayer(playerNumber, 1, true);
        }
       else if (!hurdleFound)
        {
            ShootSceneStateManager.Instance.setNextTurnFlag(true);
        }
        m_ready = true;

    }
    IEnumerator ShowHurdle(int playerNum,int hurdleNum) {
        GameObject[] track;
        m_tracks.TryGetValue("player_" + playerNum + "_Track", out track);
        GameObject h = track[hurdleNum];
        h.SetActive(true);
        yield return new WaitForSeconds(1f);
        h.SetActive(false);
    }
    IEnumerator PlayGettingExtraChance(Player player) {
        yield return new WaitForSeconds(1f);
        GameObject effect= ManagerHandler.managerHandler.allEffects.Heart;
        Instantiate(effect, player.transform.position+Vector3.up, Quaternion.identity);
        ManagerHandler.managerHandler.shootSceneStateManager.playerGettingChance = true;
        ShootSceneStateManager.Instance.setNextTurnFlag(true);
    }
    IEnumerator PlaySkipChance(Player player)
    {
        yield return new WaitForSeconds(1f);
        GameObject effect = ManagerHandler.managerHandler.allEffects.HeartBreak;
        Instantiate(effect, player.transform.position + Vector3.up, Quaternion.identity);
        player.SetSkip(true);
        ShootSceneStateManager.Instance.setNextTurnFlag(true);
    }

    IEnumerator PlaySelfDestruct(Player player,int playerNum) {
        setCameraToNormal(playerNum);
        yield return new WaitForSeconds(1f);
        GameObject[] effects = new GameObject[2];
        effects[0] = ManagerHandler.managerHandler.allEffects.DeathSkull;
        effects[1] = ManagerHandler.managerHandler.allEffects.Blast;
        foreach (var effect in effects) {
            Instantiate(effect, player.gameObject.transform.position+Vector3.up, Quaternion.identity);
        }
        StartCoroutine(PlayWaitForSelfDieEffect(player,playerNum));

    }
    IEnumerator PlayWaitForSelfDieEffect(Player player,int playerNum) {
        player.gameObject.GetComponent<Animator>().SetBool("death", true);
        yield return new WaitForSeconds(1.5f);
        GameObject[] track;
        int playerIndex = playerNum;
        m_tracks.TryGetValue("player_" + playerIndex + "_Track", out track);
        player.gameObject.transform.position = track[0].transform.position;
        player.gameObject.GetComponent<Animator>().SetBool("death", false);
        m_player_pos.Remove("player_" + playerIndex);
        m_player_pos.Add("player_" + playerIndex, 0);
        player.SetScore(0);
       yield return new WaitForSeconds(1.5f);
        ShootSceneStateManager.Instance.setNextTurnFlag(true);
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
        setCameraToNormal(playerNumber);
        sideVcam.m_Priority = 11;
        GameObject current_Player;
        m_players.TryGetValue("player_" + playerNumber, out current_Player);
        int pos;
        m_player_pos.TryGetValue("player_" + playerNumber, out pos);
        if (movingForward)
        {
            pos = (pos + steps) > 22 ? pos : (pos + steps);
        }
        else
        {
            pos = (pos - steps) < 0 ? pos : (pos - steps);
        }
       // pos += (movingForward? steps:(0-steps));
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
                   managerHandler.audioManager.PlayAudio(AudioSourceType.ANIMEF, AudioCLips.AC_Running_track, true);
           }).OnComplete(() =>
           {
               current_Player.GetComponent<Animator>().SetBool("jump", false);
               current_Player.GetComponent<DustEffect>().StopParticle();
               managerHandler.audioManager.PlayAudio(AudioSourceType.ANIMEF, AudioCLips.AC_None, true);

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
    public GameObject GetPlayer(int playerIndex)
    {
       // int playerIndex = PlayerPrefs.GetInt("Turn");
        GameObject player = null;
        m_players.TryGetValue("player_" + playerIndex, out player);
        return player;
    }

    public GameObject GetOppPlayer()
    {
        int playerIndex = PlayerPrefs.GetInt("Turn")+1;
        if (playerIndex > 2) {
            playerIndex = 1;
        }
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
        if (m_dollyCam.m_PathPosition >= 23+20-sortedHurdles[hurdleNumber-1].pos)
        {
            StartCoroutine(ShowHurdles(sortedHurdles[hurdleNumber - 1].pos));
        }
    }

    public void ResetGame()
    {
        managerHandler.homeScreenManager.GoToHomeScreenHomePage();
        SceneManager.LoadScene(0);
    }
}
