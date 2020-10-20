using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GaragePoints : MonoBehaviour {
    public static GaragePoints Instance { get; protected set; }
    [SerializeField]
    public GroupOfPoints m_environmentPoints ;

    [SerializeField]
    public GroupOfPoints m_barEnvironmentPoints;
    [SerializeField]
    public GroupOfPoints m_CSEnvironmentPoints;
    [SerializeField]
    public GroupOfPoints m_trainEnvironmentPoints;
    [SerializeField]
    public GroupOfPoints m_shipEnvironmentPoints;
    private void Awake()
    {
        Instance = this;
    }
    public GroupOfPoints getEnvironmentPoints() {
        return m_environmentPoints;
    }
    public GroupOfPoints getBarEnvironmentPoints()
    {
        return m_barEnvironmentPoints;
    }
    public GroupOfPoints getCSEnvironmentPoints()
    {
        return m_CSEnvironmentPoints;
    }
    public GroupOfPoints getTrainEnvironmentPoints()
    {
        return m_trainEnvironmentPoints;
    }
    public GroupOfPoints getShipEnvironmentPoints()
    {
        return m_shipEnvironmentPoints;
    }


}
