using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatusBlock : MonoBehaviour
{
    [SerializeField] private Color failedColor;
    [SerializeField] private Color succesColor;
    private Image uiImage;

    void Start()
    {
        uiImage = GetComponent<Image>();
    }

    public void ChangeColor(bool state)
    {
        if (uiImage != null)
        {

            if (state)
            {
                uiImage.color = succesColor;
            }
            else
            {
                uiImage.color = failedColor;
            }
        }
    }


}
