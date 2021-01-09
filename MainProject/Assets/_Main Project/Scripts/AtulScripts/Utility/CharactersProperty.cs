using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class CharactersProperty : MonoBehaviour
{
    public Image CharImage;
    public TextMeshProUGUI CharName;
    public TextMeshProUGUI CharPoints;

    public void SetDeafult(Sprite charSprite, string charName, string charPoints)
    {
        CharImage.sprite = charSprite;
        CharName.text = charName;
        CharPoints.text = charPoints;
    }
}
