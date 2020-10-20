using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class IntroCanvasHandler : MonoBehaviour 
{
    #region Private Variables 

    [SerializeField]
	private Slider m_progressBar;
	[SerializeField]
	private float m_barFillDuration = 4;

	#endregion

	void Start () 
	{
		m_progressBar.value = 0;
		m_progressBar.DOValue(1, m_barFillDuration);
	}
}
