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
    GroupOfPoints pointGroup;
    public Canvas loadingSceneCanvas;
    public GameObject gameManager;
    public GameObject character;
    private void Awake()
    {
        

    }
    void Start()
    {
        pointGroup = GaragePoints.Instance.getCSEnvironmentPoints();



    }
    public void InitializeScene() {
        setShootPoint();
        setBurglarStartPoint();
        setBurglarEndPoint();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void setShootPoint() {
        print(pointGroup.shootPositions[0].transform.position);
        character.transform.position = pointGroup.shootPositions[0].transform.position;
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
            m_burglar[i].transform.position = pointGroup.groupOfPoints[list.ElementAt(rint)].startPoint.transform.position;
            listEndPoints.Add(list.ElementAt(rint));
            list.RemoveAt(rint);
            m_burglar[i].GetComponent<NavMeshAgent>().enabled = true;
        }
    }
    void setBurglarEndPoint()
    {
        for (int i = 0; i < 5; i++)
        {
            if(pointGroup.groupOfPoints[listEndPoints[i]].endPoints.Count>0)
            m_burglar[i].SetDestination(pointGroup.groupOfPoints[listEndPoints[i]].endPoints[0].transform);
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
        ShootSceneStateManager.Instance.ToggleAppState(ShootState.Result);

    }
}
