using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupController : MonoBehaviour
{
    public TextMeshProUGUI msgToDisplay;
    public AnimationEndEvent animationEndEvent;
    private void Awake()
    {
        animationEndEvent.OnAnimationEnd += OnMsgDone;
    }
    public void OnMsgDone()
    {
        Destroy(this.gameObject);
    }
    private void OnDestroy()
    {
        animationEndEvent.OnAnimationEnd -= OnMsgDone;
    }
}
