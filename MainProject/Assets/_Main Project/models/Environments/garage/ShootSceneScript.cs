using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ShootSceneScript : MonoBehaviour
{
    [SerializeField]
    private ManagerHandler managerHandler;
    // Start is called before the first frame update
    public GameObject PointsCanvas;
    public Burglar[] m_burglar;
    GroupOfPoints[] pointGroup;
    public Canvas loadingSceneCanvas;
    public GameObject character;
    CameraShaker ch;
    Controller con;

    private void Awake()
    {
        pointGroup = new GroupOfPoints[5];
        ch = character.GetComponentInChildren<CameraShaker>();
        con = character.GetComponentInChildren<Controller>();
    }
    void Start()
    {
        pointGroup[0] = GaragePoints.Instance.getEnvironmentPoints();
        pointGroup[1] = GaragePoints.Instance.getCSEnvironmentPoints();
        pointGroup[2] = GaragePoints.Instance.getTrainEnvironmentPoints();
        pointGroup[3] = GaragePoints.Instance.getBarEnvironmentPoints();
        pointGroup[4] = GaragePoints.Instance.getShipEnvironmentPoints();
    }
    int EnvironmentNum;
    void setEnvironment(EnviromentType enviromentType)
    {
        managerHandler.lightingManager.ChangeLightingData(enviromentType);
    }
    public IEnumerator InitializeScene(int en, Action OnComplete = null)
    {
        EnvironmentNum = en;
        setEnvironment((EnviromentType)en);
        setShootPoint(en);
        setBurglarStartPoint2();
        setBurglarStartPoint();
        setBurglarEndPoint();
        yield return new WaitForSecondsRealtime(AppStateManager.instance.SubStateDelay);
        OnComplete?.Invoke();
    }

    void setShootPoint(int en)
    {
        character.transform.position = pointGroup[en].shootPositions[0].transform.position;
        ch.gameObject.transform.localRotation = pointGroup[en].shootPositions[0].transform.localRotation;
        con.setMRotations();
    }
    public void setBurglerNoneAnimation()
    {
        for (int i = 0; i < 5; i++)
        {

            m_burglar[i].NoneAnimation();

        }
    }
    List<int> listEndPoints = new List<int>();
    List<int[]> listOfPoints = new List<int[]>();

    void setBurglarStartPoint()
    {
        List<int> list = new List<int> { 19, 12, 0, 18, 2, 11, 17, 5, 7, 16, 10, 6, 15, 3, 9, 1, 14, 8, 4, 13 };

        int rint;
        for (int i = 0; i < 5; i++)
        {
            m_burglar[i].GetComponent<NavMeshAgent>().enabled = false;
            // rint = Random.Range(0, list.Count - 1);
            //  m_burglar[i].transform.position = pointGroup[EnvironmentNum].groupOfPoints[list.ElementAt(rint)].startPoint.transform.position;
            // m_burglar[i].SetStartPosition(pointGroup[EnvironmentNum].groupOfPoints[list.ElementAt(rint)].startPoint.transform);
            // listEndPoints.Add(list.ElementAt(rint));
            //  list.RemoveAt(rint);
            Points[] setOfPoints = new Points[4];
            for (int y = 0; y < 4; y++)
            {
                setOfPoints[y] = pointGroup[EnvironmentNum].groupOfPoints[listOfPoints[i].ElementAt(y)];
            }
            m_burglar[i].setPoints(setOfPoints);
            m_burglar[i].GetComponent<NavMeshAgent>().enabled = true;
        }
    }

    void setBurglarStartPoint2()
    {
        List<int> list = new List<int> { 19, 12, 0, 18, 2, 11, 17, 5, 7, 16, 10, 6, 15, 3, 9, 1, 14, 8, 4, 13 };

        int rint;
        for (int i = 0; i < 5; i++)
        {
            int[] rintarray = new int[4];
            for (int y = 0; y < 4; y++)
            {

                rint = UnityEngine.Random.Range(0, list.Count - 1);
                rintarray[y] = list.ElementAt(rint);
                list.RemoveAt(rint);
            }
            listOfPoints.Add(rintarray);
        }

    }
    void setBurglarEndPoint()
    {
        for (int i = 0; i < 5; i++)
        {
            // if (pointGroup[EnvironmentNum].groupOfPoints[listEndPoints[i]].endPoints.Count > 0)
            m_burglar[i].SetDestination();
        }
        listEndPoints.Clear();
    }

    public void AddShotEffects()
    {
        Time.timeScale = 0.6f;
        // VigneteEffect.Instance.VigneteEffectStart();
    }

    public void CameraEffect(string msg)
    {
        con.InactiveScope();
        StartCoroutine(AfterDieEffect(msg));
    }
    IEnumerator AfterDieEffect(string msg)
    {
        yield return new WaitForSeconds(2f);
        DisplayPoints(msg);
        Time.timeScale = 1f;
    }
    public void DisplayPoints(string msg)
    {
        PointsCanvas.SetActive(true);

        PointsCanvas.GetComponentInChildren<TextMeshProUGUI>().text = msg;

    }
    public void LoadScene()
    {
        StartCoroutine(LoadBirdViewScene());
    }
    IEnumerator LoadBirdViewScene()
    {
        yield return new WaitForSeconds(5);
        PointsCanvas.SetActive(false);
        managerHandler.appStateManager.ToggleApp(AppState.GameScreen, AppSubState.GameScreen_BirdviewMode);
        managerHandler.switchCamera.ShootCameraEnable(false);
        managerHandler.lightingManager.ChangeLightingData(EnviromentType.BirdView);
        yield return new WaitForSecondsRealtime(AppStateManager.instance.SubStateDelay);
        ShootSceneStateManager.Instance.ToggleAppState(ShootState.Result);
    }
}
