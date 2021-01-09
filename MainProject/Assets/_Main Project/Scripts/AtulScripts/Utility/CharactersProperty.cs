using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System;

namespace GammaXR
{
    namespace UI
    {
        public class CharactersProperty : MonoBehaviour
        {
            [SerializeField]
            private Image CharImage;
            [SerializeField]
            private TextMeshProUGUI CharName;
            [SerializeField]
            private TextMeshProUGUI CharPoints;

            public void SetDeafult(Sprite charSprite, string charName, string charPoint)
            {
                CharImage.sprite = charSprite;
                CharName.text = charName;
                CharPoints.text = charPoint;
            }
            public void SetPoint(string charPoint)
            {
                CharPoints.text = charPoint;
            }
        }
    }
}

