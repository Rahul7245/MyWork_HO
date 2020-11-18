using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;


public enum EnviromentType
{
    BirdView = 5,
    Garage = 0,
    CountrySide = 1,
    Train = 2,
    Bar = 3,
    Ship = 4
}

public class LightingManager : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject soundManager;
    public AudioSource audioSource;
    public AudioClip audioClipShip;
    public AudioClip audioClipTrain;
    public AudioClip audioClipGerag;
    public AudioClip audioClipCS;
    public AudioClip audioClipbar;
    public ManagerHandler managerHandler;
    public Texture2D agarge;
    public Texture2D aagarge;
    public Texture2D agarge1;
    public Texture2D aagarge1;
    public Texture2D agarge2;
    public Texture2D aagarge2;
    public Texture2D agarge3;
    public Texture2D aagarge3;
    public Texture2D agarge4;
    public Texture2D aagarge4;
    public Texture2D agarge5;
    public Texture2D aagarge5;
    public Texture2D agarge6;
    public Texture2D aagarge6;
    public Texture2D agarge7;
    public Texture2D aagarge7;
    public Texture2D agarge8;
    public Texture2D aagarge8;
    public Texture2D agarge9;
    public Texture2D aagarge9;
    public Texture2D agarge10;
    public Texture2D aagarge10;
    public Texture2D agarge11;
    public Texture2D aagarge11;
    public Texture2D agarge12;
    public Texture2D aagarge12;
    public Texture2D agarge13;
    public Texture2D aagarge13;
    public Texture2D agarge14;
    public Texture2D aagarge14;
    public Texture2D agarge15;
    public Texture2D aagarge15;
    public Texture2D agarge16;
    public Texture2D aagarge16;
    public Texture2D agarge17;
    public Texture2D aagarge17;
    public Texture2D abar;
    public Texture2D aabar;
    public Texture2D abar1;
    public Texture2D aabar1;
    public Texture2D abar2;
    public Texture2D aabar2;
    public Texture2D abar3;
    public Texture2D aabar3;
    public Texture2D abar4;
    public Texture2D aabar4;
    public Texture2D abar5;
    public Texture2D aabar5;
    public Texture2D abar6;
    public Texture2D aabar6;
    public Texture2D abar7;
    public Texture2D aabar7;
    public Texture2D abar8;
    public Texture2D aabar8;
    public Texture2D abar9;
    public Texture2D aabar9;
    public Texture2D abar10;
    public Texture2D aabar10;
    public Texture2D abar11;
    public Texture2D aabar11;
    public Texture2D abar12;
    public Texture2D aabar12;
    public Texture2D abar13;
    public Texture2D aabar13;
    public Texture2D abar14;
    public Texture2D aabar14;
    public Texture2D abar15;
    public Texture2D aabar15;
    public Texture2D abar16;
    public Texture2D aabar16;
    public Texture2D abar17;
    public Texture2D aabar17;
    public Texture2D acountry_side;
    public Texture2D aacountry_side;
    public Texture2D acountry_side1;
    public Texture2D aacountry_side1;
    public Texture2D acountry_side2;
    public Texture2D aacountry_side2;
    public Texture2D acountry_side3;
    public Texture2D aacountry_side3;
    public Texture2D acountry_side4;
    public Texture2D aacountry_side4;
    public Texture2D acountry_side5;
    public Texture2D aacountry_side5;
    public Texture2D acountry_side6;
    public Texture2D aacountry_side6;
    public Texture2D acountry_side7;
    public Texture2D aacountry_side7;
    public Texture2D acountry_side8;
    public Texture2D aacountry_side8;
    public Texture2D acountry_side9;
    public Texture2D aacountry_side9;
    public Texture2D acountry_side10;
    public Texture2D aacountry_side10;
    public Texture2D acountry_side11;
    public Texture2D aacountry_side11;
    public Texture2D acountry_side12;
    public Texture2D aacountry_side12;
    public Texture2D acountry_side13;
    public Texture2D aacountry_side13;
    public Texture2D acountry_side14;
    public Texture2D aacountry_side14;
    public Texture2D acountry_side15;
    public Texture2D aacountry_side15;
    public Texture2D acountry_side16;
    public Texture2D aacountry_side16;
    public Texture2D acountry_side17;
    public Texture2D aacountry_side17;
    public Texture2D atrain;
    public Texture2D aatrain;
    public Texture2D atrain1;
    public Texture2D aatrain1;
    public Texture2D atrain2;
    public Texture2D aatrain2;
    public Texture2D atrain3;
    public Texture2D aatrain3;
    public Texture2D atrain4;
    public Texture2D aatrain4;
    public Texture2D atrain5;
    public Texture2D aatrain5;
    public Texture2D atrain6;
    public Texture2D aatrain6;
    public Texture2D atrain7;
    public Texture2D aatrain7;
    public Texture2D atrain8;
    public Texture2D aatrain8;
    public Texture2D atrain9;
    public Texture2D aatrain9;
    public Texture2D atrain10;
    public Texture2D aatrain10;
    public Texture2D atrain11;
    public Texture2D aatrain11;
    public Texture2D atrain12;
    public Texture2D aatrain12;
    public Texture2D atrain13;
    public Texture2D aatrain13;
    public Texture2D atrain14;
    public Texture2D aatrain14;
    public Texture2D atrain15;
    public Texture2D aatrain15;
    public Texture2D atrain16;
    public Texture2D aatrain16;
    public Texture2D atrain17;
    public Texture2D aatrain17;
    public Texture2D aship;
    public Texture2D aaship;
    public Texture2D aship1;
    public Texture2D aaship1;
    public Texture2D aship2;
    public Texture2D aaship2;
    public Texture2D aship3;
    public Texture2D aaship3;
    public Texture2D aship4;
    public Texture2D aaship4;
    public Texture2D aship5;
    public Texture2D aaship5;
    public Texture2D aship6;
    public Texture2D aaship6;
    public Texture2D aship7;
    public Texture2D aaship7;
    public Texture2D aship8;
    public Texture2D aaship8;
    public Texture2D aship9;
    public Texture2D aaship9;
    public Texture2D aship10;
    public Texture2D aaship10;
    public Texture2D aship11;
    public Texture2D aaship11;
    public Texture2D aship12;
    public Texture2D aaship12;
    public Texture2D aship13;
    public Texture2D aaship13;
    public Texture2D aship14;
    public Texture2D aaship14;
    public Texture2D aship15;
    public Texture2D aaship15;
    public Texture2D aship16;
    public Texture2D aaship16;
    public Texture2D aship17;
    public Texture2D aaship17;
    public Texture2D abirdview;
    public Texture2D aaabirdview;
    public Texture2D abirdview1;
    public Texture2D aaabirdview1;
    public Texture2D abirdview2;
    public Texture2D aaabirdview2;
    public Texture2D abirdview3;
    public Texture2D aaabirdview3;
    public Texture2D abirdview4;
    public Texture2D aaabirdview4;
    public Texture2D abirdview5;
    public Texture2D aaabirdview5;
    public Texture2D abirdview6;
    public Texture2D aaabirdview6;
    public Texture2D abirdview7;
    public Texture2D aaabirdview7;
    public Texture2D abirdview8;
    public Texture2D aaabirdview8;
    public Texture2D abirdview9;
    public Texture2D aaabirdview9;
    public Texture2D abirdview10;
    public Texture2D aaabirdview10;
    public Texture2D abirdview11;
    public Texture2D aaabirdview11;
    public Texture2D abirdview12;
    public Texture2D aaabirdview12;
    public Texture2D abirdview13;
    public Texture2D aaabirdview13;
    public Texture2D abirdview14;
    public Texture2D aaabirdview14;
    public Texture2D abirdview15;
    public Texture2D aaabirdview15;
    public Texture2D abirdview16;
    public Texture2D aaabirdview16;
    public Texture2D abirdview17;
    public Texture2D aaabirdview17;
    public Material garge;
    public Material bar;
    public Material country_side;
    public Material train;
    public Material ship;
    public Material birdview;
    public GameObject birdveiw_light;
    public GameObject birdveiw_Env;
    public GameObject garge_Env;
    public GameObject bar_Env;
    public GameObject country_side_Env;
    public GameObject train_Env;
    public GameObject ship_Env;



    private Dictionary<EnviromentType, GameObject> enviromentDic = new Dictionary<EnviromentType, GameObject>();
    private LightmapData[] lightmapDatagarge = new LightmapData[18];
    private LightmapData[] lightmapDatabar = new LightmapData[18];
    private LightmapData[] lightmapDatacountry_side = new LightmapData[18];
    private LightmapData[] lightmapDatatrain = new LightmapData[18];
    private LightmapData[] lightmapDataship = new LightmapData[18];
    private LightmapData[] lightmapDatabirdview = new LightmapData[18];

    private void Awake()
    {
        enviromentDic.Add(EnviromentType.Bar, bar_Env);
        enviromentDic.Add(EnviromentType.BirdView, birdveiw_Env);
        enviromentDic.Add(EnviromentType.CountrySide, country_side_Env);
        enviromentDic.Add(EnviromentType.Garage, garge_Env);
        enviromentDic.Add(EnviromentType.Train, train_Env);
        enviromentDic.Add(EnviromentType.Ship, ship_Env);
        foreach (var item in enviromentDic)
        {
            if (item.Value != null)
            {
                item.Value.SetActive(false);
            }
        }
        enviromentDic[EnviromentType.BirdView]?.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        lightmapDatagarge[0] = new LightmapData();
        lightmapDatagarge[0].lightmapDir = agarge;
        lightmapDatagarge[0].lightmapColor = aagarge;
        lightmapDatagarge[1] = new LightmapData();
        lightmapDatagarge[1].lightmapDir = agarge1;
        lightmapDatagarge[1].lightmapColor = aagarge1;
        lightmapDatagarge[2] = new LightmapData();
        lightmapDatagarge[2].lightmapDir = agarge2;
        lightmapDatagarge[2].lightmapColor = aagarge2;
        lightmapDatagarge[3] = new LightmapData();
        lightmapDatagarge[3].lightmapDir = agarge3;
        lightmapDatagarge[3].lightmapColor = aagarge3;
        lightmapDatagarge[4] = new LightmapData();
        lightmapDatagarge[4].lightmapDir = agarge4;
        lightmapDatagarge[4].lightmapColor = aagarge4;
        lightmapDatagarge[5] = new LightmapData();
        lightmapDatagarge[5].lightmapDir = agarge5;
        lightmapDatagarge[5].lightmapColor = aagarge5;
        lightmapDatagarge[6] = new LightmapData();
        lightmapDatagarge[6].lightmapDir = agarge6;
        lightmapDatagarge[6].lightmapColor = aagarge6;
        lightmapDatagarge[7] = new LightmapData();
        lightmapDatagarge[7].lightmapDir = agarge7;
        lightmapDatagarge[7].lightmapColor = aagarge7;
        lightmapDatagarge[8] = new LightmapData();
        lightmapDatagarge[8].lightmapDir = agarge8;
        lightmapDatagarge[8].lightmapColor = aagarge8;
        lightmapDatagarge[9] = new LightmapData();
        lightmapDatagarge[9].lightmapDir = agarge9;
        lightmapDatagarge[9].lightmapColor = aagarge9;
        lightmapDatagarge[10] = new LightmapData();
        lightmapDatagarge[10].lightmapDir = agarge10;
        lightmapDatagarge[10].lightmapColor = aagarge10;
        lightmapDatagarge[11] = new LightmapData();
        lightmapDatagarge[11].lightmapDir = agarge11;
        lightmapDatagarge[11].lightmapColor = aagarge11;
        lightmapDatagarge[12] = new LightmapData();
        lightmapDatagarge[12].lightmapDir = agarge12;
        lightmapDatagarge[12].lightmapColor = aagarge12;
        lightmapDatagarge[13] = new LightmapData();
        lightmapDatagarge[13].lightmapDir = agarge13;
        lightmapDatagarge[13].lightmapColor = aagarge13;
        lightmapDatagarge[14] = new LightmapData();
        lightmapDatagarge[14].lightmapDir = agarge14;
        lightmapDatagarge[14].lightmapColor = aagarge14;
        lightmapDatagarge[15] = new LightmapData();
        lightmapDatagarge[15].lightmapDir = agarge15;
        lightmapDatagarge[15].lightmapColor = aagarge15;
        lightmapDatagarge[16] = new LightmapData();
        lightmapDatagarge[16].lightmapDir = agarge16;
        lightmapDatagarge[16].lightmapColor = aagarge16;
        lightmapDatagarge[17] = new LightmapData();
        lightmapDatagarge[17].lightmapDir = agarge17;
        lightmapDatagarge[17].lightmapColor = aagarge17;


        lightmapDatabar[0] = new LightmapData();
        lightmapDatabar[0].lightmapDir = abar;
        lightmapDatabar[0].lightmapColor = aabar;
        lightmapDatabar[1] = new LightmapData();
        lightmapDatabar[1].lightmapDir = abar1;
        lightmapDatabar[1].lightmapColor = aabar1;
        lightmapDatabar[2] = new LightmapData();
        lightmapDatabar[2].lightmapDir = abar2;
        lightmapDatabar[2].lightmapColor = aabar2;
        lightmapDatabar[3] = new LightmapData();
        lightmapDatabar[3].lightmapDir = abar3;
        lightmapDatabar[3].lightmapColor = aabar3;
        lightmapDatabar[4] = new LightmapData();
        lightmapDatabar[4].lightmapDir = abar4;
        lightmapDatabar[4].lightmapColor = aabar4;
        lightmapDatabar[5] = new LightmapData();
        lightmapDatabar[5].lightmapDir = abar5;
        lightmapDatabar[5].lightmapColor = aabar5;
        lightmapDatabar[6] = new LightmapData();
        lightmapDatabar[6].lightmapDir = abar6;
        lightmapDatabar[6].lightmapColor = aabar6;
        lightmapDatabar[7] = new LightmapData();
        lightmapDatabar[7].lightmapDir = abar7;
        lightmapDatabar[7].lightmapColor = aabar7;
        lightmapDatabar[8] = new LightmapData();
        lightmapDatabar[8].lightmapDir = abar8;
        lightmapDatabar[8].lightmapColor = aabar8;
        lightmapDatabar[9] = new LightmapData();
        lightmapDatabar[9].lightmapDir = abar9;
        lightmapDatabar[9].lightmapColor = aabar9;
        lightmapDatabar[10] = new LightmapData();
        lightmapDatabar[10].lightmapDir = abar10;
        lightmapDatabar[10].lightmapColor = aabar10;
        lightmapDatabar[11] = new LightmapData();
        lightmapDatabar[11].lightmapDir = abar11;
        lightmapDatabar[11].lightmapColor = aabar11;
        lightmapDatabar[12] = new LightmapData();
        lightmapDatabar[12].lightmapDir = abar12;
        lightmapDatabar[12].lightmapColor = aabar12;
        lightmapDatabar[13] = new LightmapData();
        lightmapDatabar[13].lightmapDir = abar13;
        lightmapDatabar[13].lightmapColor = aabar13;
        lightmapDatabar[14] = new LightmapData();
        lightmapDatabar[14].lightmapDir = abar14;
        lightmapDatabar[14].lightmapColor = aabar14;
        lightmapDatabar[15] = new LightmapData();
        lightmapDatabar[15].lightmapDir = abar15;
        lightmapDatabar[15].lightmapColor = aabar15;
        lightmapDatabar[16] = new LightmapData();
        lightmapDatabar[16].lightmapDir = abar16;
        lightmapDatabar[16].lightmapColor = aabar16;
        lightmapDatabar[17] = new LightmapData();
        lightmapDatabar[17].lightmapDir = abar17;
        lightmapDatabar[17].lightmapColor = aabar17;

        lightmapDatacountry_side[0] = new LightmapData();
        lightmapDatacountry_side[0].lightmapDir = acountry_side;
        lightmapDatacountry_side[0].lightmapColor = aacountry_side;
        lightmapDatacountry_side[1] = new LightmapData();
        lightmapDatacountry_side[1].lightmapDir = acountry_side1;
        lightmapDatacountry_side[1].lightmapColor = aacountry_side1;
        lightmapDatacountry_side[2] = new LightmapData();
        lightmapDatacountry_side[2].lightmapDir = acountry_side2;
        lightmapDatacountry_side[2].lightmapColor = aacountry_side2;
        lightmapDatacountry_side[3] = new LightmapData();
        lightmapDatacountry_side[3].lightmapDir = acountry_side3;
        lightmapDatacountry_side[3].lightmapColor = aacountry_side3;
        lightmapDatacountry_side[4] = new LightmapData();
        lightmapDatacountry_side[4].lightmapDir = acountry_side4;
        lightmapDatacountry_side[4].lightmapColor = aacountry_side4;
        lightmapDatacountry_side[5] = new LightmapData();
        lightmapDatacountry_side[5].lightmapDir = acountry_side5;
        lightmapDatacountry_side[5].lightmapColor = aacountry_side5;
        lightmapDatacountry_side[6] = new LightmapData();
        lightmapDatacountry_side[6].lightmapDir = acountry_side6;
        lightmapDatacountry_side[6].lightmapColor = aacountry_side6;
        lightmapDatacountry_side[7] = new LightmapData();
        lightmapDatacountry_side[7].lightmapDir = acountry_side7;
        lightmapDatacountry_side[7].lightmapColor = aacountry_side7;
        lightmapDatacountry_side[8] = new LightmapData();
        lightmapDatacountry_side[8].lightmapDir = acountry_side8;
        lightmapDatacountry_side[8].lightmapColor = aacountry_side8;
        lightmapDatacountry_side[9] = new LightmapData();
        lightmapDatacountry_side[9].lightmapDir = acountry_side9;
        lightmapDatacountry_side[9].lightmapColor = aacountry_side9;
        lightmapDatacountry_side[10] = new LightmapData();
        lightmapDatacountry_side[10].lightmapDir = acountry_side10;
        lightmapDatacountry_side[10].lightmapColor = aacountry_side10;
        lightmapDatacountry_side[11] = new LightmapData();
        lightmapDatacountry_side[11].lightmapDir = acountry_side11;
        lightmapDatacountry_side[11].lightmapColor = aacountry_side11;
        lightmapDatacountry_side[12] = new LightmapData();
        lightmapDatacountry_side[12].lightmapDir = acountry_side12;
        lightmapDatacountry_side[12].lightmapColor = aacountry_side12;
        lightmapDatacountry_side[13] = new LightmapData();
        lightmapDatacountry_side[13].lightmapDir = acountry_side13;
        lightmapDatacountry_side[13].lightmapColor = aacountry_side13;
        lightmapDatacountry_side[14] = new LightmapData();
        lightmapDatacountry_side[14].lightmapDir = acountry_side14;
        lightmapDatacountry_side[14].lightmapColor = aacountry_side14;
        lightmapDatacountry_side[15] = new LightmapData();
        lightmapDatacountry_side[15].lightmapDir = acountry_side15;
        lightmapDatacountry_side[15].lightmapColor = aacountry_side15;
        lightmapDatacountry_side[16] = new LightmapData();
        lightmapDatacountry_side[16].lightmapDir = acountry_side16;
        lightmapDatacountry_side[16].lightmapColor = aacountry_side16;
        lightmapDatacountry_side[17] = new LightmapData();
        lightmapDatacountry_side[17].lightmapDir = acountry_side17;
        lightmapDatacountry_side[17].lightmapColor = aacountry_side17;


        lightmapDatatrain[0] = new LightmapData();
        lightmapDatatrain[0].lightmapDir = atrain;
        lightmapDatatrain[0].lightmapColor = aatrain;
        lightmapDatatrain[1] = new LightmapData();
        lightmapDatatrain[1].lightmapDir = atrain1;
        lightmapDatatrain[1].lightmapColor = aatrain1;
        lightmapDatatrain[2] = new LightmapData();
        lightmapDatatrain[2].lightmapDir = atrain2;
        lightmapDatatrain[2].lightmapColor = aatrain2;
        lightmapDatatrain[3] = new LightmapData();
        lightmapDatatrain[3].lightmapDir = atrain3;
        lightmapDatatrain[3].lightmapColor = aatrain3;
        lightmapDatatrain[4] = new LightmapData();
        lightmapDatatrain[4].lightmapDir = atrain4;
        lightmapDatatrain[4].lightmapColor = aatrain4;
        lightmapDatatrain[5] = new LightmapData();
        lightmapDatatrain[5].lightmapDir = atrain5;
        lightmapDatatrain[5].lightmapColor = aatrain5;
        lightmapDatatrain[6] = new LightmapData();
        lightmapDatatrain[6].lightmapDir = atrain6;
        lightmapDatatrain[6].lightmapColor = aatrain6;
        lightmapDatatrain[7] = new LightmapData();
        lightmapDatatrain[7].lightmapDir = atrain7;
        lightmapDatatrain[7].lightmapColor = aatrain7;
        lightmapDatatrain[8] = new LightmapData();
        lightmapDatatrain[8].lightmapDir = atrain8;
        lightmapDatatrain[8].lightmapColor = aatrain8;
        lightmapDatatrain[9] = new LightmapData();
        lightmapDatatrain[9].lightmapDir = atrain9;
        lightmapDatatrain[9].lightmapColor = aatrain9;
        lightmapDatatrain[10] = new LightmapData();
        lightmapDatatrain[10].lightmapDir = atrain10;
        lightmapDatatrain[10].lightmapColor = aatrain10;
        lightmapDatatrain[11] = new LightmapData();
        lightmapDatatrain[11].lightmapDir = atrain11;
        lightmapDatatrain[11].lightmapColor = aatrain11;
        lightmapDatatrain[12] = new LightmapData();
        lightmapDatatrain[12].lightmapDir = atrain12;
        lightmapDatatrain[12].lightmapColor = aatrain12;
        lightmapDatatrain[13] = new LightmapData();
        lightmapDatatrain[13].lightmapDir = atrain13;
        lightmapDatatrain[13].lightmapColor = aatrain13;
        lightmapDatatrain[14] = new LightmapData();
        lightmapDatatrain[14].lightmapDir = atrain14;
        lightmapDatatrain[14].lightmapColor = aatrain14;
        lightmapDatatrain[15] = new LightmapData();
        lightmapDatatrain[15].lightmapDir = atrain15;
        lightmapDatatrain[15].lightmapColor = aatrain15;
        lightmapDatatrain[16] = new LightmapData();
        lightmapDatatrain[16].lightmapDir = atrain16;
        lightmapDatatrain[16].lightmapColor = aatrain16;
        lightmapDatatrain[17] = new LightmapData();
        lightmapDatatrain[17].lightmapDir = atrain17;
        lightmapDatatrain[17].lightmapColor = aatrain17;

        lightmapDataship[0] = new LightmapData();
        lightmapDataship[0].lightmapDir = aship;
        lightmapDataship[0].lightmapColor = aaship;
        lightmapDataship[1] = new LightmapData();
        lightmapDataship[1].lightmapDir = aship1;
        lightmapDataship[1].lightmapColor = aaship1;
        lightmapDataship[2] = new LightmapData();
        lightmapDataship[2].lightmapDir = aship2;
        lightmapDataship[2].lightmapColor = aaship2;
        lightmapDataship[3] = new LightmapData();
        lightmapDataship[3].lightmapDir = aship3;
        lightmapDataship[3].lightmapColor = aaship3;
        lightmapDataship[4] = new LightmapData();
        lightmapDataship[4].lightmapDir = aship4;
        lightmapDataship[4].lightmapColor = aaship4;
        lightmapDataship[5] = new LightmapData();
        lightmapDataship[5].lightmapDir = aship5;
        lightmapDataship[5].lightmapColor = aaship5;
        lightmapDataship[6] = new LightmapData();
        lightmapDataship[6].lightmapDir = aship6;
        lightmapDataship[6].lightmapColor = aaship6;
        lightmapDataship[7] = new LightmapData();
        lightmapDataship[7].lightmapDir = aship7;
        lightmapDataship[7].lightmapColor = aaship7;
        lightmapDataship[8] = new LightmapData();
        lightmapDataship[8].lightmapDir = aship8;
        lightmapDataship[8].lightmapColor = aaship8;
        lightmapDataship[9] = new LightmapData();
        lightmapDataship[9].lightmapDir = aship9;
        lightmapDataship[9].lightmapColor = aaship9;
        lightmapDataship[10] = new LightmapData();
        lightmapDataship[10].lightmapDir = aship10;
        lightmapDataship[10].lightmapColor = aaship10;
        lightmapDataship[11] = new LightmapData();
        lightmapDataship[11].lightmapDir = aship11;
        lightmapDataship[11].lightmapColor = aaship11;
        lightmapDataship[12] = new LightmapData();
        lightmapDataship[12].lightmapDir = aship12;
        lightmapDataship[12].lightmapColor = aaship12;
        lightmapDataship[13] = new LightmapData();
        lightmapDataship[13].lightmapDir = aship13;
        lightmapDataship[13].lightmapColor = aaship13;
        lightmapDataship[14] = new LightmapData();
        lightmapDataship[14].lightmapDir = aship14;
        lightmapDataship[14].lightmapColor = aaship14;
        lightmapDataship[15] = new LightmapData();
        lightmapDataship[15].lightmapDir = aship15;
        lightmapDataship[15].lightmapColor = aaship15;
        lightmapDataship[16] = new LightmapData();
        lightmapDataship[16].lightmapDir = aship16;
        lightmapDataship[16].lightmapColor = aaship16;
        lightmapDataship[17] = new LightmapData();
        lightmapDataship[17].lightmapDir = aship17;
        lightmapDataship[17].lightmapColor = aaship17;

        lightmapDatabirdview[0] = new LightmapData();
        lightmapDatabirdview[0].lightmapDir = abirdview;
        lightmapDatabirdview[0].lightmapColor = aaabirdview;
        lightmapDatabirdview[1] = new LightmapData();
        lightmapDatabirdview[1].lightmapDir = abirdview1;
        lightmapDatabirdview[1].lightmapColor = aaabirdview1;
        lightmapDatabirdview[2] = new LightmapData();
        lightmapDatabirdview[2].lightmapDir = abirdview2;
        lightmapDatabirdview[2].lightmapColor = aaabirdview2;
        lightmapDatabirdview[3] = new LightmapData();
        lightmapDatabirdview[3].lightmapDir = abirdview3;
        lightmapDatabirdview[3].lightmapColor = aaabirdview3;
        lightmapDatabirdview[4] = new LightmapData();
        lightmapDatabirdview[4].lightmapDir = abirdview4;
        lightmapDatabirdview[4].lightmapColor = aaabirdview4;
        lightmapDatabirdview[5] = new LightmapData();
        lightmapDatabirdview[5].lightmapDir = abirdview5;
        lightmapDatabirdview[5].lightmapColor = aaabirdview5;
        lightmapDatabirdview[6] = new LightmapData();
        lightmapDatabirdview[6].lightmapDir = abirdview6;
        lightmapDatabirdview[6].lightmapColor = aaabirdview6;
        lightmapDatabirdview[7] = new LightmapData();
        lightmapDatabirdview[7].lightmapDir = abirdview7;
        lightmapDatabirdview[7].lightmapColor = aaabirdview7;
        lightmapDatabirdview[8] = new LightmapData();
        lightmapDatabirdview[8].lightmapDir = abirdview8;
        lightmapDatabirdview[8].lightmapColor = aaabirdview8;
        lightmapDatabirdview[9] = new LightmapData();
        lightmapDatabirdview[9].lightmapDir = abirdview9;
        lightmapDatabirdview[9].lightmapColor = aaabirdview9;
        lightmapDatabirdview[10] = new LightmapData();
        lightmapDatabirdview[10].lightmapDir = abirdview10;
        lightmapDatabirdview[10].lightmapColor = aaabirdview10;
        lightmapDatabirdview[11] = new LightmapData();
        lightmapDatabirdview[11].lightmapDir = abirdview11;
        lightmapDatabirdview[11].lightmapColor = aaabirdview11;
        lightmapDatabirdview[12] = new LightmapData();
        lightmapDatabirdview[12].lightmapDir = abirdview12;
        lightmapDatabirdview[12].lightmapColor = aaabirdview12;
        lightmapDatabirdview[13] = new LightmapData();
        lightmapDatabirdview[13].lightmapDir = abirdview13;
        lightmapDatabirdview[13].lightmapColor = aaabirdview13;
        lightmapDatabirdview[14] = new LightmapData();
        lightmapDatabirdview[14].lightmapDir = abirdview14;
        lightmapDatabirdview[14].lightmapColor = aaabirdview14;
        lightmapDatabirdview[15] = new LightmapData();
        lightmapDatabirdview[15].lightmapDir = abirdview15;
        lightmapDatabirdview[15].lightmapColor = aaabirdview15;
        lightmapDatabirdview[16] = new LightmapData();
        lightmapDatabirdview[16].lightmapDir = abirdview16;
        lightmapDatabirdview[16].lightmapColor = aaabirdview16;
        lightmapDatabirdview[17] = new LightmapData();
        lightmapDatabirdview[17].lightmapDir = abirdview17;
        lightmapDatabirdview[17].lightmapColor = aaabirdview17;


    }

    // Update is called once per frame
    public void ChangeLightingData(EnviromentType enviromentType)
    {

        switch (enviromentType)
        {
            case EnviromentType.Ship:
                mainCamera.GetComponent<SunShafts>().enabled = false;
                mainCamera.GetComponent<ColorCorrectionCurves>().enabled = false;
                mainCamera.GetComponent<VignetteAndChromaticAberration>().enabled = false;
                LightmapSettings.lightmaps = lightmapDataship;
                RenderSettings.skybox = ship;
                soundManager.SetActive(false);
                audioSource.clip = audioClipShip;
                audioSource.Play();
                birdveiw_light.SetActive(false);
                foreach (var item in enviromentDic)
                {
                    if (item.Value != null)
                    {
                        item.Value.SetActive(false);
                    }
                }
                enviromentDic[EnviromentType.Ship]?.SetActive(true);
                break;
            case EnviromentType.Garage:
                mainCamera.GetComponent<SunShafts>().enabled = false;
                mainCamera.GetComponent<ColorCorrectionCurves>().enabled = false;
                mainCamera.GetComponent<VignetteAndChromaticAberration>().enabled = false;
                LightmapSettings.lightmaps = lightmapDatagarge;
                RenderSettings.skybox = garge;
                soundManager.SetActive(false);
                audioSource.clip = audioClipGerag;
                audioSource.Play();
                birdveiw_light.SetActive(false);
                foreach (var item in enviromentDic)
                {
                    if (item.Value != null)
                    {
                        item.Value.SetActive(false);
                    }
                }
                enviromentDic[EnviromentType.Garage]?.SetActive(true);
                break;

            case EnviromentType.Bar:
                mainCamera.GetComponent<SunShafts>().enabled = false;
                mainCamera.GetComponent<ColorCorrectionCurves>().enabled = false;
                mainCamera.GetComponent<VignetteAndChromaticAberration>().enabled = false;
                LightmapSettings.lightmaps = lightmapDatabar;
                RenderSettings.skybox = bar;
                soundManager.SetActive(false);
                audioSource.clip = audioClipbar;
                audioSource.Play();
                birdveiw_light.SetActive(false);
                foreach (var item in enviromentDic)
                {
                    if (item.Value != null)
                    {
                        item.Value.SetActive(false);
                    }
                }
                enviromentDic[EnviromentType.Bar]?.SetActive(true);
                break;
            case EnviromentType.CountrySide:
                mainCamera.GetComponent<SunShafts>().enabled = false;
                mainCamera.GetComponent<ColorCorrectionCurves>().enabled = false;
                mainCamera.GetComponent<VignetteAndChromaticAberration>().enabled = false;
                LightmapSettings.lightmaps = lightmapDatacountry_side;
                RenderSettings.skybox = country_side;
                soundManager.SetActive(false);
                audioSource.clip = audioClipCS;
                audioSource.Play();
                birdveiw_light.SetActive(false);
                foreach (var item in enviromentDic)
                {
                    if (item.Value != null)
                    {
                        item.Value.SetActive(false);
                    }
                }
                enviromentDic[EnviromentType.CountrySide]?.SetActive(true);
                break;
            case EnviromentType.Train:
                mainCamera.GetComponent<SunShafts>().enabled = true;
                mainCamera.GetComponent<ColorCorrectionCurves>().enabled = true;
                mainCamera.GetComponent<VignetteAndChromaticAberration>().enabled = true;
                LightmapSettings.lightmaps = lightmapDatatrain;
                RenderSettings.skybox = train;
                soundManager.SetActive(false);
                audioSource.clip = audioClipTrain;
                audioSource.Play();
                birdveiw_light.SetActive(false);
                foreach (var item in enviromentDic)
                {
                    if (item.Value != null)
                    {
                        item.Value.SetActive(false);
                    }
                }
                enviromentDic[EnviromentType.Train]?.SetActive(true);
                break;
            case EnviromentType.BirdView:
                audioSource.Stop();
                soundManager.SetActive(true);
                LightmapSettings.lightmaps = lightmapDatabirdview;
                RenderSettings.skybox = birdview;
                birdveiw_light.SetActive(true);
                foreach (var item in enviromentDic)
                {
                    if (item.Value != null)
                    {
                        item.Value.SetActive(false);
                    }
                }
                enviromentDic[EnviromentType.BirdView]?.SetActive(true);
                break;


        }

    }
}