using TMPro;
using UnityEngine.UI;
using UnityEngine;

namespace GammaXR
{
    namespace UI
    {
        public class CharactersProperty : MonoBehaviour
        {
            public Image CharImage;
            public TextMeshProUGUI CharName;
            public TextMeshProUGUI CharPoints;

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

