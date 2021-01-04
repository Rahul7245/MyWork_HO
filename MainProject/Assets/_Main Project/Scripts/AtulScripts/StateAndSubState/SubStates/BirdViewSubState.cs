using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdViewSubState : SubState
{
    private void Awake()
    {
        AnimationEvents animationEndEvent = subStateTranistionCanvasGrup.GetComponentInChildren<AnimationEvents>();
        if (animationEndEvent)
        {
            animationEndEvent.OnAnimationEnd += () => { subStateTranistionCanvasGrup.gameObject.SetActive(false); };
        }
    }
}
