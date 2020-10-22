using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingTest : MonoBehaviour
{
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
    public void ChangeLightingData(int i)
    {
        switch (i)
        {
            case 0:
                LightmapSettings.lightmaps = lightmapDatagarge;
                RenderSettings.skybox = garge;
                break;

            case 3:
                LightmapSettings.lightmaps = lightmapDatabar;
                RenderSettings.skybox = bar;
                break;
            case 1:
                LightmapSettings.lightmaps = lightmapDatacountry_side;
                RenderSettings.skybox = country_side;
                break;
            case 2:
                LightmapSettings.lightmaps = lightmapDatatrain;
                RenderSettings.skybox = train;
                break;
            case 4:
                LightmapSettings.lightmaps = lightmapDatabirdview;
                RenderSettings.skybox = birdview;
                break;


        }

    }
}