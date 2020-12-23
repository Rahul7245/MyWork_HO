using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private ManagerHandler managerHandler;

    // Enviroment Audio 
    public AudioSource audioSourceEnv;
    public AudioClip audioClipBirdView;
    public AudioClip audioClipShipView;
    public AudioClip audioClipTrainView;
    public AudioClip audioClipGeragView;
    public AudioClip audioClipCSView;
    public AudioClip audioClipbarView;
}
