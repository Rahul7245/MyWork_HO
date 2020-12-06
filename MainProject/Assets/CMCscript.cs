using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

public class CMCscript : MonoBehaviour
{
    // Start is called before the first frame update
    bool is_revolving;
    public CinemachineVirtualCamera confettiCamera;
    CinemachineTrackedDolly m_dollyCam;
   // PlayableDirector m_director;
    void Start()
    {
       // confettiCamera = gameObject.GetComponentInChildren<CinemachineVirtualCamera>();
        m_dollyCam = confettiCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
      //  m_director = confettiCamera.GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (is_revolving == true) {
            m_dollyCam.m_PathPosition += 0.5f * Time.fixedDeltaTime;
        }
    }
    public void SetLookAtProperty(Player player) {
        confettiCamera.LookAt = player.gameObject.transform;
    }
    public void StartRevolution() {
        is_revolving = true;
    }
    public void StopRevolution()
    {
        is_revolving = false;
        m_dollyCam.m_PathPosition = 0;
    }
}
