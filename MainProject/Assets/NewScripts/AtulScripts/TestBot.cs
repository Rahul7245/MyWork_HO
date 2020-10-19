using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBot : MonoBehaviour
{
    [SerializeField]
    public List<int> proPlayer;
    [SerializeField]
    public List<int> interPlayer;
    [SerializeField]
    public List<int> noobPlayer;

    // Start is called before the first frame update
    void Start()
    {
        int botScore = 0;
        // for pro player
        /*foreach (var item in proPlayer)
        {
            
        }*/
        botScore = ShootingBot.BotPlay(proPlayer.ToArray());
        Debug.Log("@#$ For Pro-PLayer Bot has scored : " + botScore);

        // for intermediate player
        /* foreach (var item in interPlayer)
         {
             botScore = ShootingBot.BotPlay(item.ToArray());
             Debug.Log("@#$ For Intermidiate-Player Bot has scored : " + botScore);
         }*/
        botScore = ShootingBot.BotPlay(interPlayer.ToArray());
        Debug.Log("@#$ For Pro-PLayer Bot has scored : " + botScore);

        // for noob player
        /*foreach (var item in noobPlayer)
        {
            botScore = ShootingBot.BotPlay(item.ToArray());
            Debug.Log("@#$ For Noob-PLayer Bot has scored : " + botScore);
        }*/
        botScore = ShootingBot.BotPlay(noobPlayer.ToArray());
        Debug.Log("@#$ For Pro-PLayer Bot has scored : " + botScore);
    }
}
