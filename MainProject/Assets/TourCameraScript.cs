using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourCameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void AfterTourCall() {
        ShootSceneStateManager.Instance.AfterTour();

    }
}
