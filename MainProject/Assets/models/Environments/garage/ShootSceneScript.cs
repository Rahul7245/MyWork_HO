using System.Collections;
using System.Collections.Generic;
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
    private void Awake()
    {
        

    }
    void Start()
    {
        pointGroup = GaragePoints.Instance.getEnvironmentPoints();



    }
    public void InitializeScene() {
        setBurglarStartPoint();
        setBurglarEndPoint();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

   public  void setBurglerNoneAnimation() {
        for (int i = 0; i < 5; i++)
        {

            m_burglar[i].NoneAnimation();
            
        }
    }
    void setBurglarStartPoint() {
        for (int i = 0; i < 5; i++)
        {
            m_burglar[i].GetComponent<NavMeshAgent>().enabled = false;
            m_burglar[i].transform.position = pointGroup.groupOfPoints[i].startPoint.transform.position;
            m_burglar[i].GetComponent<NavMeshAgent>().enabled = true;
        }
    }
    void setBurglarEndPoint()
    {
        for (int i = 0; i < 5; i++)
        {
            if(pointGroup.groupOfPoints[i].endPoints.Count>0)
            m_burglar[i].SetDestination(pointGroup.groupOfPoints[i].endPoints[0].transform);
        }
    }

   public void AddShotEffects() {
        Time.timeScale = 0.6f;
        VigneteEffect.Instance.VigneteEffectStart();
    }

    public void CameraEffect() {
        StartCoroutine(AfterDieEffect());
    }
    IEnumerator AfterDieEffect() {
        yield return new WaitForSeconds(2f);
        DisplayPoints();
        Time.timeScale = 1f;
    }
    public void DisplayPoints() {
        PointsCanvas.SetActive(true);
       
        PointsCanvas.GetComponentInChildren<TextMeshProUGUI>().text = "You Shot " + PlayerPrefs.GetInt("Score");

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
