using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace GammaXR
{
    namespace Popup
    {
        public enum PopupType
        {
            Msg_Popup = 0,
            Msg_Two_Btn_Popup
        }

        public class PopupController : MonoBehaviour
        {
            public TextMeshProUGUI msgToDisplay;
            public Transform popUpImage;
            public Button btn_One;
            public Button btn_Two;
        }
    }
}
