using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivitySlider : MonoBehaviour
{
	 Slider mainSlider;

	public void Start()
	{
		mainSlider = gameObject.GetComponent<Slider>();
		mainSlider.value = ManagerHandler.managerHandler.controller.MouseSensitivity;
		//Adds a listener to the main slider and invokes a method when the value changes.
		mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
	}

	// Invoked when the value of the slider changes.
	public void ValueChangeCheck()
	{
		ManagerHandler.managerHandler.controller.ChangeMouseSensitivity(mainSlider.value);
	}
	
}
