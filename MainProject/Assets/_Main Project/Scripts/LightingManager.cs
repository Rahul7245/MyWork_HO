﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    public Material garge;
    public Material bar;
    public Material country_side;
    public Material train;
    public Material ship;
    public Material birdview;
    public GameObject birdveiw_light;
   


    private LightmapData[] lightmapDatagarge = new LightmapData[12];
    private LightmapData[] lightmapDatabar = new LightmapData[12];
    private LightmapData[] lightmapDatacountry_side = new LightmapData[12];
    private LightmapData[] lightmapDatatrain = new LightmapData[12];
    private LightmapData[] lightmapDataship = new LightmapData[12];
    private LightmapData[] lightmapDatabirdview = new LightmapData[12];
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
                birdveiw_light.SetActive(false);
                break;
            case EnviromentType.Garage:
                LightmapSettings.lightmaps = lightmapDatagarge;
                RenderSettings.skybox = garge;
                soundManager.SetActive(false);
                audioSource.clip = audioClipGerag;
                audioSource.Play();
                birdveiw_light.SetActive(false);
                break;

            case EnviromentType.Bar:
                LightmapSettings.lightmaps = lightmapDatabar;
                RenderSettings.skybox = bar;
                soundManager.SetActive(false);
                audioSource.clip = audioClipbar;
                audioSource.Play();
                birdveiw_light.SetActive(false);
                break;
            case EnviromentType.CountrySide:
                LightmapSettings.lightmaps = lightmapDatacountry_side;
                RenderSettings.skybox = country_side;
                soundManager.SetActive(false);
                audioSource.clip = audioClipCS;
                audioSource.Play();
                birdveiw_light.SetActive(false);
                break;
            case EnviromentType.Train:
                LightmapSettings.lightmaps = lightmapDatatrain;
                RenderSettings.skybox = train;
                soundManager.SetActive(false);
                audioSource.clip = audioClipTrain;
                audioSource.Play();
                birdveiw_light.SetActive(false);
                break;
            case EnviromentType.BirdView:
                audioSource.Stop();
                soundManager.SetActive(true);
                LightmapSettings.lightmaps = lightmapDatabirdview;
                RenderSettings.skybox = birdview;
                birdveiw_light.SetActive(true);
                break;


        }

    }
}