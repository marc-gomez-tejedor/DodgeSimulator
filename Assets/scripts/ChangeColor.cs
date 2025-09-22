using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public Color color1;
    public Color color2;
    public Image image;

    public void swapColor()
    {
        image.color = color2;
    }
    public void resetColor()
    {
        image.color = color1;
    }
}
