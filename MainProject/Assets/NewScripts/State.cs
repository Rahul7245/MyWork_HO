using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected StateMachineBehaviour m_stateMachineBehaviour;
    public State(StateMachineBehaviour stateMachineBehaviour) {
        m_stateMachineBehaviour = stateMachineBehaviour;
    }
    public virtual IEnumerator Start()
    {
        yield break;
    }
    public virtual IEnumerator Run() {
        yield break;
    }
    public virtual IEnumerator Shoot()
    {
        yield break;
    }
}
