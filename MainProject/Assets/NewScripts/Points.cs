using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Points 
{
  public  GameObject startPoint;
  public  List<GameObject> endPoints;
}
[System.Serializable]
public class GroupOfPoints {
  public  List<Points> groupOfPoints;
}

/*ublic class EnvironmentPoints {
    List<GroupOfPoints> m_environmentPoints;

    public void setEnvironmentPoints(List<GroupOfPoints> groupOfPoints) {
        m_environmentPoints = groupOfPoints;
    }
    
    public List<GroupOfPoints> getEnvironmentPoints() {
        return m_environmentPoints;
    }
}
*/