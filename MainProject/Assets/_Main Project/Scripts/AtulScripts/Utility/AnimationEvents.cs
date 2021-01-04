using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public Action OnAnimationEnd;
    public Action OnAimationMid;
    public Action OnAnimationStart;
    public Action OnAnimationCustoum;
    public void AnimationEnd()
    {
        OnAnimationEnd?.Invoke();
    }
    public void AnimationMid()
    {
        OnAimationMid?.Invoke();
    }
    public void AnimationStart()
    {
        OnAnimationStart?.Invoke();
    }
    public void AnimationCustoum()
    {
        OnAnimationCustoum?.Invoke();
    }
}
