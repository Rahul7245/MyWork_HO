using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Burglar[] m_burglar;
    void Start()
    {
        GroupOfPoints pointGroup= GaragePoints.Instance.getEnvironmentPoints();
        m_burglar[0].SetDestination(pointGroup.groupOfPoints[4].endPoints[0].transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
