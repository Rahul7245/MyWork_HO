using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public enum AudioSourceType
{
    ENV = 0,
    BG,
    ANIMEF,
    UI
}

public enum AudioCLips
{
    AC_None = 0,
    AC_BirdView,
    AC_ShipView,
    AC_TrainView,
    AC_GeragView,
    AC_BarView,
    AC_Pages,
    AC_CSView,
    AC_Character01_selection,
    AC_Character02_selection,
    AC_Character03_selection,
    AC_Character04_selection,
    AC_Character05_selection,
    AC_Character06_selection,
    AC_Hurdule_Self_die,
    AC_Hurdule_Self_add2,
    AC_Hurdule_Self_sub2,
    AC_Hurdule_Self_Skip,
    AC_Hurdule_Self_life,
    AC_Hurdule_Rival_die,
    AC_Hurdule_Rival_skip,
    AC_Hurdule_Rival_Help,
    AC_Hurdule_Rival_Back,
    AC_BgMusic,
    AC_Win,
    AC_Running_track,
    AC_Timmer,
    AC_SlowMotion,
    AC_Die,
    AC_Shoot,
    AC_Btn_Click
}

public class AudioManager : MonoBehaviour
{
    private AudioCLips previousAC_Env;
    private AudioCLips previousAC_Bg;
    private AudioCLips previousAC_Anim;
    private AudioCLips previousAC_Ui;
    [SerializeField]
    private ManagerHandler managerHandler;

    // Enviroment Audio 
    [SerializeField]
    private AudioSource AS_Env;
    [SerializeField]
    private AudioClip AC_BirdView;
    [SerializeField]
    private AudioClip AC_ShipView;
    [SerializeField]
    private AudioClip AC_TrainView;
    [SerializeField]
    private AudioClip AC_GeragView;
    [SerializeField]
    private AudioClip AC_BarView;
    [SerializeField]
    private AudioClip AC_CSView;
    [SerializeField]
    private AudioClip AC_Pages;


    // Background Audio 
    [SerializeField]
    private AudioSource AS_BG;
    [SerializeField]
    private AudioClip AC_BG;

    // Animation Effcet Audio 
    [SerializeField]
    private AudioSource AS_AnimEf;
    [SerializeField]
    private AudioClip AC_Character01_selection;
    [SerializeField]
    private AudioClip AC_Character02_selection;
    [SerializeField]
    private AudioClip AC_Character03_selection;
    [SerializeField]
    private AudioClip AC_Character04_selection;
    [SerializeField]
    private AudioClip AC_Character05_selection;
    [SerializeField]
    private AudioClip AC_Character06_selection;
    [SerializeField]
    private AudioClip AC_Hurdule_Self_die;
    [SerializeField]
    private AudioClip AC_Hurdule_Self_add2;
    [SerializeField]
    private AudioClip AC_Hurdule_Self_sub2;
    [SerializeField]
    private AudioClip AC_Hurdule_Self_Skip;
    [SerializeField]
    private AudioClip AC_Hurdule_Self_life;
    [SerializeField]
    private AudioClip AC_Hurdule_Rival_die;
    [SerializeField]
    private AudioClip AC_Hurdule_Rival_skip;
    [SerializeField]
    private AudioClip AC_Hurdule_Rival_Help;
    [SerializeField]
    private AudioClip AC_Hurdule_Rival_Back;
    [SerializeField]
    private AudioClip AC_Win;
    [SerializeField]
    private AudioClip AC_Running_track;
    [SerializeField]
    private AudioClip AC_Timmer;
    [SerializeField]
    private AudioClip AC_SlowMotion;
    [SerializeField]
    private AudioClip AC_Die;
    [SerializeField]
    private AudioClip AC_Shoot;

    // UI audio 
    [SerializeField]
    private AudioSource AS_UI;
    [SerializeField]
    private AudioClip AC_Btn_Click;

    public void PlayAudio(AudioSourceType audioSource, AudioCLips audioCLips, bool loopClip = false)
    {
        SetCip(audioSource, audioCLips, loopClip);
        PlayAudioSource(audioSource, audioCLips);
    }
    public void ToggleAudioSource(AudioSourceType audioSourceType, bool status)
    {
        switch (audioSourceType)
        {
            case AudioSourceType.ANIMEF:
                AS_AnimEf.mute = !status;
                if (!status && AS_AnimEf.isPlaying)
                {
                    AS_AnimEf.Stop();
                }
                break;
            case AudioSourceType.BG:
                AS_BG.mute = !status;
                if (!status && AS_BG.isPlaying)
                {
                    AS_BG.Stop();
                }
                break;
            case AudioSourceType.ENV:
                AS_Env.mute = !status;
                if (status)
                {
                    if (!AS_Env.isPlaying)
                    {
                        AS_Env.Play();
                    }
                }
                else
                {
                    if (AS_Env.isPlaying)
                    {
                        AS_Env.Stop();
                    }
                }
                break;
            case AudioSourceType.UI:
                AS_UI.mute = !status;
                if(!status && AS_UI.isPlaying)
                {
                    AS_UI.Stop();
                }
                break;
        }
    }
    private void PlayAudioSource(AudioSourceType audioSourceType, AudioCLips audioCLips)
    {
        switch (audioSourceType)
        {
            case AudioSourceType.ANIMEF:
                if(previousAC_Anim == audioCLips)
                {
                    if (!AS_AnimEf.gameObject.activeInHierarchy)
                    {
                        AS_AnimEf.gameObject.SetActive(true);
                        AS_AnimEf.Play();
                    }
                    else
                    {
                        if (!AS_AnimEf.isPlaying)
                        {
                            AS_AnimEf.gameObject.SetActive(true);
                            AS_AnimEf.Play();
                        }
                    }
                }
                else
                {
                    previousAC_Anim = audioCLips;
                    AS_AnimEf.gameObject.SetActive(true);
                    AS_AnimEf.Play();
                }

                break;
            case AudioSourceType.BG:
                if(previousAC_Bg == audioCLips)
                {
                    if (!AS_BG.gameObject.activeInHierarchy)
                    {
                        AS_BG.gameObject.SetActive(true);
                        AS_BG.Play();
                    }
                    else
                    {
                        if (!AS_BG.isPlaying)
                        {
                            AS_BG.gameObject.SetActive(true);
                            AS_BG.Play();
                        }
                    }
                }
                else
                {
                    previousAC_Bg = audioCLips;
                    AS_BG.gameObject.SetActive(true);
                    AS_BG.Play();
                }

                break;
            case AudioSourceType.ENV:
                if(previousAC_Env == audioCLips)
                {
                    if (!AS_Env.gameObject.activeInHierarchy)
                    {
                        AS_Env.gameObject.SetActive(true);
                        AS_Env.Play();
                    }
                    else
                    {
                        if (!AS_Env.isPlaying)
                        {
                            AS_Env.gameObject.SetActive(true);
                            AS_Env.Play();
                        }
                    }
                }
                else
                {
                    previousAC_Env = audioCLips;
                    AS_Env.gameObject.SetActive(true);
                    AS_Env.Play();
                }

                break;
            case AudioSourceType.UI:
                if(previousAC_Ui == audioCLips)
                {
                    if (!AS_UI.gameObject.activeInHierarchy)
                    {
                        AS_UI.gameObject.SetActive(true);
                        AS_UI.Play();
                    }
                    else
                    {
                        if (!AS_UI.isPlaying)
                        {
                            AS_UI.gameObject.SetActive(true);
                            AS_UI.Play();
                        }
                    }
                }
                else
                {
                    previousAC_Ui = audioCLips;
                    AS_UI.gameObject.SetActive(true);
                    AS_UI.Play();
                }
                break;
        }
    }
    private void SetCip(AudioSourceType audioSource , AudioCLips audioCLips, bool loopClip)
    {
        switch (audioSource)
        {
            case AudioSourceType.ANIMEF:
                previousAC_Anim = audioCLips;
                switch (audioCLips)
                {
                    case AudioCLips.AC_Character01_selection:
                        SetAudioClip(AC_Character01_selection, AS_AnimEf, loopClip);
                        break;
                    case AudioCLips.AC_Character02_selection:
                        SetAudioClip(AC_Character02_selection, AS_AnimEf, loopClip);
                        break;
                    case AudioCLips.AC_Character03_selection:
                        SetAudioClip(AC_Character03_selection, AS_AnimEf, loopClip);
                        break;
                    case AudioCLips.AC_Character04_selection:
                        SetAudioClip(AC_Character04_selection, AS_AnimEf, loopClip);
                        break;
                    case AudioCLips.AC_Character05_selection:
                        SetAudioClip(AC_Character05_selection, AS_AnimEf, loopClip);
                        break;
                    case AudioCLips.AC_Character06_selection:
                        SetAudioClip(AC_Character06_selection, AS_AnimEf, loopClip);
                        break;
                    case AudioCLips.AC_Hurdule_Self_die:
                        SetAudioClip(AC_Hurdule_Self_die, AS_AnimEf, loopClip);
                        break;
                    case AudioCLips.AC_Hurdule_Self_add2:
                        SetAudioClip(AC_Hurdule_Self_add2, AS_AnimEf, loopClip);
                        break;
                    case AudioCLips.AC_Hurdule_Self_sub2:
                        SetAudioClip(AC_Hurdule_Self_sub2, AS_AnimEf, loopClip);
                        break;
                    case AudioCLips.AC_Hurdule_Self_Skip:
                        SetAudioClip(AC_Hurdule_Self_Skip, AS_AnimEf, loopClip);
                        break;
                    case AudioCLips.AC_Hurdule_Self_life:
                        SetAudioClip(AC_Hurdule_Self_life, AS_AnimEf, loopClip);
                        break;
                    case AudioCLips.AC_Hurdule_Rival_die:
                        SetAudioClip(AC_Hurdule_Rival_die, AS_AnimEf, loopClip);
                        break;
                    case AudioCLips.AC_Hurdule_Rival_skip:
                        SetAudioClip(AC_Hurdule_Rival_skip, AS_AnimEf, loopClip);
                        break;
                    case AudioCLips.AC_Hurdule_Rival_Help:
                        SetAudioClip(AC_Hurdule_Rival_Help, AS_AnimEf, loopClip);
                        break;
                    case AudioCLips.AC_Hurdule_Rival_Back:
                        SetAudioClip(AC_Hurdule_Rival_Back, AS_AnimEf, loopClip);
                        break;
                    case AudioCLips.AC_Win:
                        SetAudioClip(AC_Win, AS_AnimEf, loopClip);
                        break;
                    case AudioCLips.AC_Running_track:
                        SetAudioClip(AC_Running_track, AS_AnimEf, loopClip);
                        break;
                    case AudioCLips.AC_Timmer:
                        SetAudioClip(AC_Timmer, AS_AnimEf, loopClip);
                        break;
                    case AudioCLips.AC_SlowMotion:
                        SetAudioClip(AC_SlowMotion, AS_AnimEf, loopClip);
                        break;
                    case AudioCLips.AC_Die:
                        SetAudioClip(AC_Die, AS_AnimEf, loopClip);
                        break;
                    case AudioCLips.AC_Shoot:
                        SetAudioClip(AC_Shoot, AS_AnimEf, loopClip);
                        break;
                    case AudioCLips.AC_None:
                        SetAudioClip(null, AS_AnimEf, loopClip);
                        break;
                }
                break;
            case AudioSourceType.BG:
                previousAC_Bg = audioCLips;
                switch (audioCLips)
                {
                    case AudioCLips.AC_BgMusic:
                        SetAudioClip(AC_BG, AS_BG, loopClip);
                        break;
                    case AudioCLips.AC_None:
                        SetAudioClip(null, AS_BG, loopClip);
                        break;
                }
                break;
            case AudioSourceType.ENV:
                previousAC_Env = audioCLips;
                switch (audioCLips)
                {
                    case AudioCLips.AC_BarView:
                        SetAudioClip(AC_BarView, AS_Env, loopClip);
                        break;
                    case AudioCLips.AC_BirdView:
                        SetAudioClip(AC_BirdView, AS_Env, loopClip);
                        break;
                    case AudioCLips.AC_CSView:
                        SetAudioClip(AC_CSView, AS_Env, loopClip);
                        break;
                    case AudioCLips.AC_GeragView:
                        SetAudioClip(AC_GeragView, AS_Env, loopClip);
                        break;
                    case AudioCLips.AC_ShipView:
                        SetAudioClip(AC_ShipView, AS_Env, loopClip);
                        break;
                    case AudioCLips.AC_TrainView:
                        SetAudioClip(AC_TrainView, AS_Env, loopClip);
                        break;
                    case AudioCLips.AC_Pages:
                        SetAudioClip(AC_Pages, AS_Env, loopClip);
                        break;
                    case AudioCLips.AC_None:
                        SetAudioClip(null, AS_Env, loopClip);
                        break;
                }
                break;
            case AudioSourceType.UI:
                previousAC_Ui = audioCLips;
                switch (audioCLips)
                {
                    case AudioCLips.AC_Btn_Click:
                        SetAudioClip(AC_Btn_Click, AS_UI, loopClip);
                        break;
                    case AudioCLips.AC_None:
                        SetAudioClip(null, AS_UI, loopClip);
                        break;
                }
                break;

        }
    }
    private void SetAudioClip(AudioClip audioClip , AudioSource audioSource, bool loopClip)
    {
        audioSource.loop = loopClip;
        audioSource.clip = audioClip;
    }
}
