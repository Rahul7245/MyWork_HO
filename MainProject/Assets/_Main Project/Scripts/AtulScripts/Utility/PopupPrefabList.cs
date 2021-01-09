using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GammaXR
{
    namespace Popup
    {
        public class PopupPrefabList : MonoBehaviour
        {
            public static PopupPrefabList instance;
            [SerializeField]
            private ManagerHandler managerHandler;
            [SerializeField]
            private List<GameObject> popupPrefabs;
            private GameObject PopupPrefab;

            private void Awake()
            {
                instance = this;
            }

            public void ShowPopup(PopupType popupType, string msg, float visbleDuration = 1, Action yesBtnAct = null, Action noBtnAct = null)
            {
                switch (popupType)
                {
                    case PopupType.Msg_Popup:
                        PopupPrefab = popupPrefabs[0];
                        ShowMsgPopup(msg, visbleDuration);
                        break;
                    case PopupType.Msg_Two_Btn_Popup:
                        PopupPrefab = popupPrefabs[1];
                        ShowTwoBtnPopup(msg, visbleDuration, yesBtnAct, noBtnAct);
                        break;
                }
            }

            private void ShowMsgPopup(string msg, float visbleDuration = 1)
            {
                GameObject obj = Instantiate(PopupPrefab);
                obj.GetComponent<PopupController>().msgToDisplay.text = msg;
                StartCoroutine(ShowPopupHelper(obj, visbleDuration));
            }

            private void ShowTwoBtnPopup(string msg, float visbleDuration = 1, Action btnOneAct = null, Action btnTwoAct = null)
            {
                GameObject obj = Instantiate(PopupPrefab);
                obj.GetComponent<PopupController>().msgToDisplay.text = msg;
                Button btn_One = obj.GetComponent<PopupController>().btn_One;
                Button btn_Two = obj.GetComponent<PopupController>().btn_Two;
                // setting the btn one action 
                if(btn_One != null && btnOneAct != null)
                {
                    btn_One.onClick.AddListener(() => {
                        btnOneAct();
                        // after doing the action must close the popup
                        obj.transform.DOScale(0, 0.5f).OnComplete(() => { Destroy(obj); });
                    });
                }
                // setting the btn two action  
                if (btn_Two != null)
                {
                    if(btnTwoAct != null)
                    {
                        btn_Two.onClick.AddListener(() => { 
                            btnTwoAct();
                            // after doing the action must close the popup
                            obj.transform.DOScale(0, 0.5f).OnComplete(() => { Destroy(obj); });
                        });
                    }
                    else
                    {
                        btn_Two.onClick.AddListener(() => { obj.transform.DOScale(0, 0.5f).OnComplete(() => { Destroy(obj); }); });
                    }
                }
                // after setting all the btn action the msg text show the popup
                obj.GetComponent<PopupController>().popUpImage.DOScale(1, 0.5f);
            }

            private IEnumerator ShowPopupHelper(GameObject obj, float visbleDuration = 1)
            {
                yield return null;
                obj.GetComponent<PopupController>().popUpImage.DOScale(1, 0.5f);
                yield return new WaitForSeconds(visbleDuration);
                obj.GetComponent<PopupController>().popUpImage.DOScale(0, 0.5f).OnComplete(() => { Destroy(obj); });
            }
        }
    }
}