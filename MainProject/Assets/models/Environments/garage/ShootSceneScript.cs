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
    // Start is called before the first frame update
    public GameObject PointsCanvas;
    public Burglar[] m_burglar;
    GroupOfPoints[] pointGroup;
    public Canvas loadingSceneCanvas;
    public GameObject gameManager;
    public GameObject character;
    public LightingManager lightingTest;
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
        lightingTest.ChangeLightingData(enviromentType);
    }
    public void InitializeScene(int en)
    {
        EnvironmentNum = en;
        Debug.Log("EN " + en);
        setEnvironment((EnviromentType)en);
        setShootPoint(en);
        setBurglarStartPoint();
        setBurglarEndPoint();
    }

    void setShootPoint(int en)
    {
        print(pointGroup[en].shootPositions[0].transform.position);
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
    void setBurglarStartPoint()
    {
        List<int> list = new List<int> { 19, 12, 0, 18, 2, 11, 17, 5, 7, 16, 10, 6, 15, 3, 9, 1, 14, 8, 4, 13 };
        int rint;
        for (int i = 0; i < 5; i++)
        {
            m_burglar[i].GetComponent<NavMeshAgent>().enabled = false;
            rint = Random.Range(0, list.Count - 1);
            m_burglar[i].transform.position = pointGroup[EnvironmentNum].groupOfPoints[list.ElementAt(rint)].startPoint.transform.position;
            m_burglar[i].SetStartPosition(pointGroup[EnvironmentNum].groupOfPoints[list.ElementAt(rint)].startPoint.transform);
            listEndPoints.Add(list.ElementAt(rint));
            list.RemoveAt(rint);
            m_burglar[i].GetComponent<NavMeshAgent>().enabled = true;
        }
    }
    void setBurglarEndPoint()
    {
        for (int i = 0; i < 5; i++)
        {
            if (pointGroup[EnvironmentNum].groupOfPoints[listEndPoints[i]].endPoints.Count > 0)
                m_burglar[i].SetDestination(pointGroup[EnvironmentNum].groupOfPoints[listEndPoints[i]].endPoints[Random.Range(0, pointGroup[EnvironmentNum].groupOfPoints[listEndPoints[i]].endPoints.Count - 1)].transform);
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
        gameManager.GetComponent<SwitchCamera>().ShootCameraEnable(false);
        lightingTest.ChangeLightingData(EnviromentType.BirdView);

        ShootSceneStateManager.Instance.ToggleAppState(ShootState.Result);

    }
}
