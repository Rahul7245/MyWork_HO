using UnityEngine;

namespace GammaXR
{
    namespace Audio
    {
        public class AudioTest : MonoBehaviour
        {
            public AudioController audioController;

            #region Unity funtions 
#if UNITY_EDITOR
            private void Update()
            {
                if (Input.GetKeyUp(KeyCode.T))
                {
                    audioController.PlayAudio(AudioType.ST_AC_BirdView);
                }
                if (Input.GetKeyUp(KeyCode.G))
                {
                    audioController.StopAudio(AudioType.ST_AC_BirdView);
                }
                if (Input.GetKeyUp(KeyCode.B))
                {
                    audioController.RestartAudio(AudioType.ST_AC_BirdView);
                }
                if (Input.GetKeyUp(KeyCode.Y))
                {
                    audioController.PlayAudio(AudioType.ST_AC_BarView);
                }
                if (Input.GetKeyUp(KeyCode.H))
                {
                    audioController.StopAudio(AudioType.ST_AC_BarView);
                }
                if (Input.GetKeyUp(KeyCode.N))
                {
                    audioController.RestartAudio(AudioType.ST_AC_BarView);
                }
            }
#endif
            #endregion
        }
    }
}

        
