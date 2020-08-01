using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreMainScreenUI : MonoBehaviour
{
    int[] disabledButton = { 0,1,2 };
    int m_state=-1;
    Button m_selected_button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PreMainScreenButtonClicked(Button currentButton)
    {
            if (m_selected_button)
            {
            
                m_selected_button.GetComponentsInChildren<Image>()[1].color = Color.white;
            m_selected_button.GetComponentInChildren<Text>().color = Color.white;
            }
        currentButton.GetComponentsInChildren<Image>()[1].color = new Color(.4f,1f,0,1f);
            currentButton.GetComponentInChildren<Text>().color = new Color(.4f, 1f, 0, 1f);
            m_selected_button = currentButton;
            

    }
}
