using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GaragePoints : MonoBehaviour {
    public static GaragePoints Instance { get; protected set; }
    [SerializeField]
    public GroupOfPoints m_environmentPoints ;
    private void Awake()
    {
        Instance = this;
    }
    public GroupOfPoints getEnvironmentPoints() {
        return m_environmentPoints;
    }


}
