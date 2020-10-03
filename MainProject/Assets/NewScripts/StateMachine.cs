using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State m_state;
    public void SetState(State state) {
        m_state = state;
        StartCoroutine(m_state.Start());
    }
}
