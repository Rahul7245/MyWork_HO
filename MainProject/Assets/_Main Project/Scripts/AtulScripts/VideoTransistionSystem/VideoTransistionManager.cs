using System.Collections;
using UnityEngine;
using UnityEditor.UI;

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

            }

            public void StopTranistion()
            {

            }

            #endregion

            #region Private Functions 

            private void Configure()
            {
                instance = this;
                ResetTransistionCanvas();

            }

            private void ResetTransistionCanvas()
            {
                transistionCanGup.alpha = 0;
                transitionParent.SetActive(false);
            }

            private void Dispose()
            {

            }

            private void GenrateAudioTable()
            {

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
