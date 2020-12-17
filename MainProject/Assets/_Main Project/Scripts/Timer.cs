﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private ManagerHandler managerHandler;
    public TextMeshProUGUI timerText;
    bool isTimerOn=false;
    public float totalTime = 10f;
    float elapsed = 0f;
    public Image timerFilling;
    // Start is called before the first frame update

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (!isTimerOn) { return; }
        elapsed += Time.deltaTime;
        if((totalTime - elapsed)>=0)
        timerFilling.fillAmount = (totalTime - elapsed) / totalTime;
        timerText.text = (totalTime-(int)elapsed).ToString();
        if (elapsed >= totalTime) {
            ShootSceneStateManager.Instance.ToggleAppState(ShootState.Shoot_Complete);
           // stopTimer();
        }
        
    }

    float scaleTime=1f;
    float scaleElapsedTime = 0f;
    private void LateUpdate()
    {

        if (!isTimerOn) { return; }
        scaleElapsedTime += Time.deltaTime;
        //timerText.gameObject.transform.localScale += new Vector3(5,5,5) * Time.deltaTime;
        if (scaleElapsedTime >= scaleTime)
        {
           // timerText.gameObject.transform.localScale = new Vector3(2, 2, 2);
            scaleElapsedTime = 0;
        }

    }
   public void startTimer() {
        managerHandler.uIInputHandlerManager.shootButton.interactable = true;
        isTimerOn = true;
    }
   public void stopTimer()
    {
        managerHandler.uIInputHandlerManager.shootButton.interactable = false;
        isTimerOn = false;
        elapsed = 0f;
    }
}
