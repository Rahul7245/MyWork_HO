using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnviromentType
{
    BirdView = 4,
    Garage = 0,
    CountrySide = 1,
    Train = 2,
    Bar = 3,
    Ship = 5
}

public class LightingManager : MonoBehaviour
{
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
    public Texture2D abar;
    public Texture2D aabar;
    public Texture2D acountry_side;
    public Texture2D aacountry_side;
    public Texture2D atrain;
    public Texture2D aatrain;
    public Texture2D aship;
    public Texture2D aaship;
    public Texture2D abirdview;
    public Texture2D aaabirdview;
    public Material garge;
    public Material bar;
    public Material country_side;
    public Material train;
    public Material ship;
    public Material birdview;




    private LightmapData[] lightmapDatagarge = new LightmapData[1];
    private LightmapData[] lightmapDatabar = new LightmapData[1];
    private LightmapData[] lightmapDatacountry_side = new LightmapData[1];
    private LightmapData[] lightmapDatatrain = new LightmapData[1];
    private LightmapData[] lightmapDataship = new LightmapData[1];
    private LightmapData[] lightmapDatabirdview = new LightmapData[1];
    // Start is called before the first frame update
    void Start()
    {
        lightmapDatagarge[0] = new LightmapData();
        lightmapDatagarge[0].lightmapDir = agarge;
        lightmapDatagarge[0].lightmapColor = aagarge;

        lightmapDatabar[0] = new LightmapData();
        lightmapDatabar[0].lightmapDir = abar;
        lightmapDatabar[0].lightmapColor = aabar;

        lightmapDatacountry_side[0] = new LightmapData();
        lightmapDatacountry_side[0].lightmapDir = acountry_side;
        lightmapDatacountry_side[0].lightmapColor = aacountry_side;

        lightmapDatatrain[0] = new LightmapData();
        lightmapDatatrain[0].lightmapDir = atrain;
        lightmapDatatrain[0].lightmapColor = aatrain;

        lightmapDataship[0] = new LightmapData();
        lightmapDataship[0].lightmapDir = aship;
        lightmapDataship[0].lightmapColor = aaship;

        lightmapDatabirdview[0] = new LightmapData();
        lightmapDatabirdview[0].lightmapDir = abirdview;
        lightmapDatabirdview[0].lightmapColor = aaabirdview;

    }

    // Update is called once per frame
    public void ChangeLightingData(EnviromentType enviromentType)
    {
        switch (enviromentType)
        {
            case EnviromentType.Ship:
                LightmapSettings.lightmaps = lightmapDataship;
                RenderSettings.skybox = ship;
                soundManager.SetActive(false);
                audioSource.clip = audioClipShip;
                audioSource.Play();
                break;
            case EnviromentType.Garage:
                LightmapSettings.lightmaps = lightmapDatagarge;
                RenderSettings.skybox = garge;
                soundManager.SetActive(false);
                audioSource.clip = audioClipGerag;
                audioSource.Play();
                break;

            case EnviromentType.Bar:
                LightmapSettings.lightmaps = lightmapDatabar;
                RenderSettings.skybox = bar;
                soundManager.SetActive(false);
                audioSource.clip = audioClipbar;
                audioSource.Play();
                break;
            case EnviromentType.CountrySide:
                LightmapSettings.lightmaps = lightmapDatacountry_side;
                RenderSettings.skybox = country_side;
                soundManager.SetActive(false);
                audioSource.clip = audioClipCS;
                audioSource.Play();
                break;
            case EnviromentType.Train:
                LightmapSettings.lightmaps = lightmapDatatrain;
                RenderSettings.skybox = train;
                soundManager.SetActive(false);
                audioSource.clip = audioClipTrain;
                audioSource.Play();
                break;
            case EnviromentType.BirdView:
                audioSource.Stop();
                soundManager.SetActive(true);
                LightmapSettings.lightmaps = lightmapDatabirdview;
                RenderSettings.skybox = birdview;
                break;


        }

    }
}