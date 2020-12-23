using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public enum AudioSourceType
{
    ENV = 0,
    BG,
    ANIMEF
}

public enum AudioCLips
{
    AC_BirdView,
    AC_ShipView,
    AC_TrainView,
    AC_GeragView,
    AC_CSView,
    AC_BarView,
    AC_AnimEff,
    AC_BgMusic

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
    public AudioClip AC_CSView;
    public AudioClip AC_BarView;

    // Background Audio 
    public AudioSource AS_BackGround;
    public AudioClip AC_BG;

    // Animation Effcet Audio 
    public AudioSource AS_AnimEf;
    public AudioClip AC_AnEf;

    public void PlayAudio(AudioSourceType audioSource, AudioCLips audioCLips)
    {
        SetCip(audioSource, audioCLips);
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
                AS_BackGround.Stop();
                AS_BackGround.gameObject.SetActive(false);
                break;
            case AudioSourceType.ENV:
                AS_Env.Stop();
                AS_Env.gameObject.SetActive(false);
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
                AS_BackGround.gameObject.SetActive(true);
                AS_BackGround.Play();

                break;
            case AudioSourceType.ENV:
                AS_Env.gameObject.SetActive(true);
                AS_Env.Play();

                break;
        }
    }
    private void SetCip(AudioSourceType audioSource , AudioCLips audioCLips)
    {
        switch (audioSource)
        {
            case AudioSourceType.ANIMEF:
                switch (audioCLips)
                {
                    case AudioCLips.AC_AnimEff:
                        SetAudioClip(AC_AnEf, AS_AnimEf);
                        break;
                }
                break;
            case AudioSourceType.BG:
                switch (audioCLips)
                {
                    case AudioCLips.AC_BgMusic:
                        SetAudioClip(AC_BG, AS_BackGround);
                        break;
                }
                break;
            case AudioSourceType.ENV:
                switch (audioCLips)
                {
                    case AudioCLips.AC_BarView:
                        SetAudioClip(AC_BarView, AS_Env);
                        break;
                    case AudioCLips.AC_BirdView:
                        SetAudioClip(AC_BirdView, AS_Env);
                        break;
                    case AudioCLips.AC_CSView:
                        SetAudioClip(AC_CSView, AS_Env);
                        break;
                    case AudioCLips.AC_GeragView:
                        SetAudioClip(AC_GeragView, AS_Env);
                        break;
                    case AudioCLips.AC_ShipView:
                        SetAudioClip(AC_ShipView, AS_Env);
                        break;
                    case AudioCLips.AC_TrainView:
                        SetAudioClip(AC_TrainView, AS_Env);
                        break;
                }
                break;

        }
    }
    private void SetAudioClip(AudioClip audioClip , AudioSource audioSource)
    {
        Debug.Log("!#$ SetAudioClip !#@");
        if (audioSource.isPlaying)
            audioSource.Stop();
        if(audioClip != null)
            audioSource.clip = audioClip;
    }
}
