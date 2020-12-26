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
    [SerializeField]
    private ManagerHandler managerHandler;

    // Enviroment Audio 
    public AudioSource AS_Env;
    public AudioClip AC_BirdView;
    public AudioClip AC_ShipView;
    public AudioClip AC_TrainView;
    public AudioClip AC_GeragView;
    public AudioClip AC_BarView;
    public AudioClip AC_CSView;
    public AudioClip AC_Pages;


    // Background Audio 
    public AudioSource AS_BG;
    public AudioClip AC_BG;

    // Animation Effcet Audio 
    public AudioSource AS_AnimEf;
    public AudioClip AC_Character01_selection;
    public AudioClip AC_Character02_selection;
    public AudioClip AC_Character03_selection;
    public AudioClip AC_Character04_selection;
    public AudioClip AC_Character05_selection;
    public AudioClip AC_Character06_selection;
    public AudioClip AC_Hurdule_Self_die;
    public AudioClip AC_Hurdule_Self_add2;
    public AudioClip AC_Hurdule_Self_sub2;
    public AudioClip AC_Hurdule_Self_Skip;
    public AudioClip AC_Hurdule_Self_life;
    public AudioClip AC_Hurdule_Rival_die;
    public AudioClip AC_Hurdule_Rival_skip;
    public AudioClip AC_Hurdule_Rival_Help;
    public AudioClip AC_Hurdule_Rival_Back;
    public AudioClip AC_Win;
    public AudioClip AC_Running_track;
    public AudioClip AC_Timmer;
    public AudioClip AC_SlowMotion;
    public AudioClip AC_Die;
    public AudioClip AC_Shoot;

    // UI audio 
    public AudioSource AS_UI;
    public AudioClip AC_Btn_Click;

    public void PlayAudio(AudioSourceType audioSource, AudioCLips audioCLips, bool loopClip = false)
    {
        
        SetCip(audioSource, audioCLips, loopClip);
        PlayAudioSource(audioSource);
    }

    public void StopAudioSource(AudioSourceType audioSourceType)
    {
        switch (audioSourceType)
        {
            case AudioSourceType.ANIMEF:
                AS_AnimEf.Stop();
                AS_AnimEf.gameObject.SetActive(false);
                break;
            case AudioSourceType.BG:
                AS_BG.Stop();
                AS_BG.gameObject.SetActive(false);
                break;
            case AudioSourceType.ENV:
                AS_Env.Stop();
                AS_Env.gameObject.SetActive(false);
                break;
            case AudioSourceType.UI:
                AS_UI.Stop();
                AS_UI.gameObject.SetActive(false);
                break;
        }
    }
    private void PlayAudioSource(AudioSourceType audioSourceType)
    {
        switch (audioSourceType)
        {
            case AudioSourceType.ANIMEF:
                AS_AnimEf.gameObject.SetActive(true);
                AS_AnimEf.Play();

                break;
            case AudioSourceType.BG:
                AS_BG.gameObject.SetActive(true);
                AS_BG.Play();

                break;
            case AudioSourceType.ENV:
                AS_Env.gameObject.SetActive(true);
                AS_Env.Play();

                break;
            case AudioSourceType.UI:
                AS_UI.gameObject.SetActive(true);
                AS_UI.Play();
                break;
        }
    }
    private void SetCip(AudioSourceType audioSource , AudioCLips audioCLips, bool loopClip)
    {
        switch (audioSource)
        {
            case AudioSourceType.ANIMEF:
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
                }
                break;
            case AudioSourceType.BG:
                switch (audioCLips)
                {
                    case AudioCLips.AC_BgMusic:
                        SetAudioClip(AC_BG, AS_BG, loopClip);
                        break;
                }
                break;
            case AudioSourceType.ENV:
                switch (audioCLips)
                {
                    case AudioCLips.AC_BarView:
                        SetAudioClip(AC_BarView, AS_Env, loopClip);
                        break;
                    case AudioCLips.AC_BirdView:
                        SetAudioClip(AC_BirdView, AS_Env, loopClip);
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

                }
                break;
            case AudioSourceType.UI:
                switch (audioCLips)
                {
                    case AudioCLips.AC_Btn_Click:
                        SetAudioClip(AC_Btn_Click, AS_UI, loopClip);
                        break;
                }
                break;

        }
    }
    private void SetAudioClip(AudioClip audioClip , AudioSource audioSource, bool loopClip)
    {
        audioSource.loop = loopClip;
        if (audioSource.isPlaying)
            audioSource.Stop();
        if(audioClip != null)
            audioSource.clip = audioClip;
    }
}
