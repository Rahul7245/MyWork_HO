using System.Collections;
using UnityEngine;

namespace GammaXR
{
    namespace Audio
    {
        public class AudioController : MonoBehaviour
        {
            // members
            public static AudioController instance;
            public bool debug;
            public AudioTrack[] audioTracks;
            private Hashtable m_AudioTable; // this is a relationship where AudioType is the 'Key' and AudioTrack is the 'Value'
            private Hashtable m_JobsTable; // this is a relationship where AudioType is the 'Key' and Jobs(CR) is the 'Value'


            [System.Serializable]
            public class AudioObject
            {
                public AudioType audioType;
                public AudioClip audioClip;
            }
            [System.Serializable]
            public class AudioTrack
            {
                public AudioSource audioSource;
                public AudioObject[] audioObjects;
            }

            #region Unity Functions

            private void Awake()
            {
                if (!instance)
                {
                    Configure();
                }
            }

            private void OnDisable()
            {
                Dispose();
            }

            #endregion

            #region Public Functions 

            public void PlayAudio(AudioType audioType)
            {

            }

            public void StopAudio(AudioType audioType)
            {

            }

            public void RestartAudio(AudioType audioType)
            {

            }

            #endregion

            #region Private Functions 

            private void Configure()
            {
                instance = this;
                m_AudioTable = new Hashtable();
                m_JobsTable = new Hashtable();
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
                Debug.Log("[AudioController]: " + _msg);
            }

            private void LogWarning(string _msg)
            {
                if (!debug)
                {
                    return;
                }
                Debug.LogWarning("[AudioController]: " + _msg);
            }
            #endregion
        }
    }
}
