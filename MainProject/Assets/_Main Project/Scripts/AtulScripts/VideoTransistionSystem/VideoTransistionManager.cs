using System.Collections;
using UnityEngine;

namespace GammaXR
{
    namespace TransistionEffect
    {
        public class VideoTransistionManager : MonoBehaviour
        {
            // members 
            public static VideoTransistionManager instance;
            public ManagerHandler managerHandler;
            public GameObject transitionParent;
            public CanvasGroup transistionCanGup;
            public AnimationEvents animationEvents;
            public bool debug;
            public bool isTransistionRunning
            {
                get { return m_CR; }
            }

            private bool m_CR;

            #region Unity Functions

            private void Awake()
            {
                Configure();
            }

            private void OnDisable()
            {
                Dispose();
            }

            #endregion

            #region Public Functions 

            public void StartTranistion()
            {
                Log("StartTranistion Called !!!");
                m_CR = true;
                transistionCanGup.alpha = 1;
                transitionParent.SetActive(true);
            }

            public void StopTranistion()
            {
                Log("StopTranistion Called !!!");
                m_CR = false; 
                ResetTransistionCanvas();
            }

            #endregion

            #region Private Functions 

            private void Configure()
            {
                Log("Configure Called !!!");
                instance = this;
                ResetTransistionCanvas();
                animationEvents.OnAnimationEnd += ResetTransistionCanvas;
            }

            private void ResetTransistionCanvas()
            {
                Log("ResetTransistionCanvas Called !!!");
                transistionCanGup.alpha = 0;
                transitionParent.SetActive(false);
            }

            private void Dispose()
            {
                Log("Dispose Called !!!");
                ResetTransistionCanvas();
                animationEvents.OnAnimationEnd -= ResetTransistionCanvas;
            }

            private void Log(string _msg)
            {
                if (!debug)
                {
                    return;
                }
                Debug.Log("[VideoTransistionManager]: " + _msg);
            }

            private void LogWarning(string _msg)
            {
                if (!debug)
                {
                    return;
                }
                Debug.LogWarning("[VideoTransistionManager]: " + _msg);
            }

            #endregion
        }
    }
}
