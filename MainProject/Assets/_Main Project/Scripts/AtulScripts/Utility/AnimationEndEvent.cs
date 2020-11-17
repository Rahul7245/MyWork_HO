using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEndEvent : MonoBehaviour
{
    public Action OnAnimationEnd;
    public void AnimationEnd()
    {
        OnAnimationEnd?.Invoke();
    }
}
