﻿//using Boo.Lang;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    /// <summary>
    /// Instance of track spawner
    /// </summary>
    public TrackSpawner trackSpawner;

    /// <summary>
    /// Instance of ImpactMAnager
    /// </summary>
    public ImpactManager impactManager;

    /// <summary>
    /// Enemy prefab to instantiate
    /// </summary>
    public GameObject Enemy;

    /// <summary>
    /// Gameobject with SpawnPositions in every environment
    /// </summary>
    public GameObject SpawnPositions;

    /// <summary>
    /// No of Enemies to be instantiated
    /// </summary>
    public int NoofEnemies = 5;

    /// <summary>
    /// Variable with properties of particular enemy
    /// </summary>
    public List<SpawnInstruction> spawnInstructions;

    /// <summary>
    /// List of given Walkable Enemies
    /// </summary>
    public String[] WalkableEn;

    /// <summary>
    /// Current environmnent for navigation
    /// </summary>
    public GameObject Environment;

    /// <summary>
    /// Timerfilling image
    /// </summary>
    public Image timerFilling;

    /// <summary>
    /// Total time given for shooting
    /// </summary>
    public float TimeAmount = 10f;

    /// <summary>
    /// Variable to save current time temporarily
    /// </summary>
    private float tempTime;

    /// <summary>
    /// Text to show countdown
    /// </summary>
    public Text timeText;

    /// <summary>
    /// Clock
    /// </summary>
    public GameObject Clock;

    /// <summary>
    /// boolean value to start timer
    /// </summary>
    public bool StartCountdown = false;

    private void Awake()
    {
        SpawnPositions = GameObject.FindGameObjectWithTag("SpawnPos");
        trackSpawner = GameObject.FindObjectOfType<TrackSpawner>();
    }

    private void Start()
    {
        Spawn();
        tempTime = TimeAmount;
        EventManager.AddReloadWeapontListener(Reset);
        EventManager.AddShootListener(Hide);
    }

    public void Spawn()
    {
        if (NoofEnemies == 0)
            Debug.LogError("Provide No of Enemies");

        for (int i = 0; i < NoofEnemies; i++)
        {
            GameObject Clone = Instantiate(Enemy, SpawnPositions.transform.GetChild(i).position, Quaternion.identity, this.transform);
            Clone.name = spawnInstructions[i].Name;
            //Adding Burger script with its value
            Clone.GetComponent<Burgler>().m_value = i + 1;

            //Assigning waypoint for movement
            int length = spawnInstructions[i].Targetpoints.Count;
            Clone.GetComponent<CustomAgent>().enabled = false;

            for (int j = 0; j < length; j++)
            {
                int trans = spawnInstructions[i].Targetpoints[j];
                Clone.GetComponent<CustomAgent>().GoalPoints[j] = SpawnPositions.transform.GetChild(trans).transform;
            }

            // Giving boolean true value which characters are walkable
            for (int k = 0; k < WalkableEn.Length; k++)
            {
                if (WalkableEn[k] == Clone.name)
                    Clone.GetComponent<CustomAgent>().isWalkable = true;
            }
        }
    }

    private void Update()
    {
        if (StartCountdown)
            CountingTime();   

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Pressed 1");
            Reset();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Pressed 2");
            Hide(1);
        }
    }


    public void CountingTime()
    {
        tempTime -= Time.deltaTime;
        timerFilling.fillAmount = tempTime / TimeAmount;
        timeText.text = tempTime.ToString("0");
        StartCoroutine(DisableTimer());
        if (timerFilling.fillAmount <= 0.25f) // when 3/4th of time filler is done shows alert color
            timerFilling.color = Color.red;
    }

    IEnumerator DisableTimer()
    {
        //print("Disable timer called");
        if (tempTime <= 0 || impactManager.ClipsizeText.activeInHierarchy || impactManager.m_points>0)
        {
            print("Disable timer called in if");
            StartCountdown = false;
            Clock.SetActive(false);
            yield return new WaitForSeconds(2f); // To show dead animation of burgler
            Time.timeScale = 1f;
            impactManager.InvokeTheEvent(impactManager.m_points);
            yield return new WaitForSeconds(2f);
            VigneteEffect.Instance.ResetVignete();
            impactManager.OkButtonClick();
        }
    }

    public void Hide(int integer)
    {
        for (int i = 0; i < NoofEnemies; i++)
        {
            GameObject obj = this.transform.GetChild(i).gameObject;
            obj.transform.position = obj.GetComponent<CustomAgent>().GoalPoints[0].position;
            obj.gameObject.SetActive(false);
            obj.GetComponent<CustomAgent>().indexvalue = 0;
        }
        StartCountdown = false;
        timerFilling.fillAmount = 1;
        tempTime = TimeAmount;
        timerFilling.color = Color.green;
        Clock.SetActive(false);
    }

    public void Reset()
    {
        foreach (Transform child in this.transform)
        {
            child.transform.gameObject.SetActive(true);
            if (child.GetComponent<CustomAgent>().isWalkable)
            {
                child.GetComponent<CustomAgent>().AnimateCharacter();
            }
        }

        StartCountdown = true;
        impactManager = GameObject.FindObjectOfType<ImpactManager>();
        Clock.SetActive(true);
        for (int i = 0; i < NoofEnemies; i++)
        {
            this.transform.GetChild(i).GetComponent<CustomAgent>().enabled = true;
        }
    }
}