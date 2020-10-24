﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ShootSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PointsCanvas;
    public Burglar[] m_burglar;
    GroupOfPoints[] pointGroup;
    public Canvas loadingSceneCanvas;
    public GameObject gameManager;
    public GameObject character;
    public LightingManager lightingTest;
    CharacterController ch;
    
    private void Awake()
    {
        pointGroup = new GroupOfPoints[4];
        ch = character.GetComponentInChildren<CharacterController>();

    }
    void Start()
    {
        pointGroup[1] = GaragePoints.Instance.getEnvironmentPoints();
        pointGroup[0] = GaragePoints.Instance.getCSEnvironmentPoints();
        pointGroup[2] = GaragePoints.Instance.getTrainEnvironmentPoints();
        pointGroup[3] = GaragePoints.Instance.getBarEnvironmentPoints();



    }
    int EnvironmentNum;
   void setEnvironment(int en) {
        lightingTest.ChangeLightingData(en);
        EnvironmentNum = en;
    }
    public void InitializeScene(int en) {
        Debug.Log("EN " + en);
        setEnvironment(en);
        setShootPoint(en);
        setBurglarStartPoint();
        setBurglarEndPoint();
    }
    
    void setShootPoint(int en) {
        EnvironmentNum = en;
        print(pointGroup[EnvironmentNum].shootPositions[0].transform.position);
        character.transform.position = pointGroup[EnvironmentNum].shootPositions[0].transform.position;
        ch.gameObject.transform.rotation = pointGroup[EnvironmentNum].shootPositions[0].transform.rotation;
        // character.transform.rotation = pointGroup[EnvironmentNum].shootPositions[0].transform.rotation;

    }
   public  void setBurglerNoneAnimation() {
        for (int i = 0; i < 5; i++)
        {

            m_burglar[i].NoneAnimation();
            
        }
    }
    List<int> listEndPoints = new List<int>();
    void setBurglarStartPoint() {
        List<int> list = new List<int>{ 0,  1, 2, 3, 4 };
        int rint;
        for (int i = 0; i < 5; i++)
        {
             m_burglar[i].GetComponent<NavMeshAgent>().enabled = false;
             rint = Random.Range(0, list.Count - 1);
            m_burglar[i].transform.position = pointGroup[EnvironmentNum].groupOfPoints[list.ElementAt(rint)].startPoint.transform.position;
            listEndPoints.Add(list.ElementAt(rint));
            list.RemoveAt(rint);
            m_burglar[i].GetComponent<NavMeshAgent>().enabled = true;
        }
    }
    void setBurglarEndPoint()
    {
        for (int i = 0; i < 5; i++)
        {
            if(pointGroup[EnvironmentNum].groupOfPoints[listEndPoints[i]].endPoints.Count>0)
            m_burglar[i].SetDestination(pointGroup[EnvironmentNum].groupOfPoints[listEndPoints[i]].endPoints[0].transform);
        }
        listEndPoints.Clear();
    }

   public void AddShotEffects() {
        Time.timeScale = 0.6f;
       // VigneteEffect.Instance.VigneteEffectStart();
    }

    public void CameraEffect(string msg) {
        StartCoroutine(AfterDieEffect(msg));
    }
    IEnumerator AfterDieEffect(string msg) {
        yield return new WaitForSeconds(2f);
        DisplayPoints(msg);
        Time.timeScale = 1f;
    }
    public void DisplayPoints(string msg) {
        PointsCanvas.SetActive(true);
       
        PointsCanvas.GetComponentInChildren<TextMeshProUGUI>().text = msg;

    }
    public void LoadScene() {
        StartCoroutine(LoadBirdViewScene());
    }
     IEnumerator LoadBirdViewScene() {
        yield return new WaitForSeconds(5);
        PointsCanvas.SetActive(false);
        gameManager.GetComponent<SwitchCamera>().ShootCameraEnable(false);
        lightingTest.ChangeLightingData(4); 
        
        ShootSceneStateManager.Instance.ToggleAppState(ShootState.Result);

    }
}
