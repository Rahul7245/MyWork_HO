using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDownScript : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI countDowntext;
    void Start()
    {
        countDowntext = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeCountDownText(int i) {
        countDowntext.text = i.ToString();
    }

}
