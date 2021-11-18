using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorBase : MonoBehaviour
{
    public Color color;

    [Header("References")]
    public Image uiImage;
    public Player player;

    private void OnValidate()
    {
        uiImage = GetComponent<Image>();
    }

    void Update()
    {
        uiImage.color = color;
    }

    public void OnClick()
    {
        player.ChangeColor(color);
    }

   
}
