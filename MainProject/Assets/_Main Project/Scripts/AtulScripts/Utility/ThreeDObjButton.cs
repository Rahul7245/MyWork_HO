using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof( BoxCollider))]
public class ThreeDObjButton : MonoBehaviour
{
    public Action<GameObject> OnClicked;

    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    private void OnMouseUp()
    {
        OnClicked?.Invoke(this.gameObject);
    }
}
