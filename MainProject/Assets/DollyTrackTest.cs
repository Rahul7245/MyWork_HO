using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DollyTrackTest : MonoBehaviour
{ /*public CinemachineTrack c;
    public CinemachineTrackedDolly c1;*/
    public CinemachineVirtualCamera c2;
    public CinemachineSmoothPath c3;
     CinemachineTrackedDolly c1;
    PlayableDirector director;
    
    // Start is called before the first frame update
    void Start()
    {
       c1= c2.GetCinemachineComponent<CinemachineTrackedDolly>();
        if (c1) {
            print("truetrue");
        }
        director = c2.GetComponent<PlayableDirector>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (c1.m_PathPosition >= 3)
        {
            print("coming here");
            director.Pause();
        }

    }
}
