using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingTest : MonoBehaviour
{
    public Texture2D a1;
    public Texture2D aa1;
    public Texture2D a2;
    public Texture2D aa2;
    public Texture2D a3;
    public Texture2D aa3;
    public Texture2D a4;
    public Texture2D aa4;
    public Texture2D a5;
    public Texture2D aa5;
    public Material garge;
    public Material bar;
    public Material ship;
    public Material train;
    public Material country_side;
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public Camera cam4;
    public Camera cam5;

    private LightmapData[] lightmapData1 = new LightmapData[1];
    private LightmapData[] lightmapData2 = new LightmapData[1];
    private LightmapData[] lightmapData3 = new LightmapData[1];
    private LightmapData[] lightmapData4 = new LightmapData[1];
    private LightmapData[] lightmapData5 = new LightmapData[1];
    // Start is called before the first frame update
    void Start()
    {
        lightmapData1[0] = new LightmapData();
        lightmapData1[0].lightmapDir = a1;
        lightmapData1[0].lightmapColor = aa1;

        lightmapData2[0] = new LightmapData();
        lightmapData2[0].lightmapDir = a2;
        lightmapData2[0].lightmapColor = aa2;

        lightmapData3[0] = new LightmapData();
        lightmapData3[0].lightmapDir = a3;
        lightmapData3[0].lightmapColor = aa3;

        lightmapData4[0] = new LightmapData();
        lightmapData4[0].lightmapDir = a4;
        lightmapData4[0].lightmapColor = aa4;

        lightmapData5[0] = new LightmapData();
        lightmapData5[0].lightmapDir = a5;
        lightmapData5[0].lightmapColor = aa5;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            LightmapSettings.lightmaps = lightmapData1;
            RenderSettings.skybox = bar;
            cam1.enabled = true;
            cam2.enabled = false;
            cam3.enabled = false;
            cam4.enabled = false;
            cam5.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LightmapSettings.lightmaps = lightmapData2;
            RenderSettings.skybox = garge;
            cam1.enabled = false;
            cam2.enabled = true;
            cam3.enabled = false;
            cam4.enabled = false;
            cam5.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            LightmapSettings.lightmaps = lightmapData3;
            RenderSettings.skybox = ship;
            cam1.enabled = false;
            cam2.enabled = false;
            cam3.enabled = true;
            cam4.enabled = false;
            cam5.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            LightmapSettings.lightmaps = lightmapData3;
            RenderSettings.skybox = train;
            cam1.enabled = false;
            cam2.enabled = false;
            cam3.enabled = false;
            cam4.enabled = true;
            cam5.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            LightmapSettings.lightmaps = lightmapData3;
            RenderSettings.skybox = country_side;
            cam1.enabled = false;
            cam2.enabled = false;
            cam3.enabled = false;
            cam4.enabled = false;
            cam5.enabled = true;
        }

    }
}