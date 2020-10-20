using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SubState : MonoBehaviour
{
    [SerializeField]
    protected AppSubState appSubState;

    public AppSubState AppSubState
    {
        get
        {
            return appSubState;
        }
    }

    public virtual void OnEnter()
    {
    }
    public virtual void OnExit()
    {
    }
}
