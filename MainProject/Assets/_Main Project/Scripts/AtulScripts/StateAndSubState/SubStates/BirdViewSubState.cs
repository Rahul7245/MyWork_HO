using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdViewSubState : SubState
{
    private void Awake()
    {
        AnimationEndEvent animationEndEvent = subStateTranistionCanvasGrup.GetComponentInChildren<AnimationEndEvent>();
        if (animationEndEvent)
        {
            animationEndEvent.OnAnimationEnd += () => { subStateTranistionCanvasGrup.gameObject.SetActive(false); };
        }
    }
}
