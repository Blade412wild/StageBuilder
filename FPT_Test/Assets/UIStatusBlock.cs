using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatusBlock : MonoBehaviour
{
    [SerializeField] private Color failedColor;
    [SerializeField] private Color succesColor;
    public bool useImage;
    [SerializeField] private Sprite failedImage;
    [SerializeField] private Sprite succesImage;
    private Image uiImage;

    void Start()
    {
        uiImage = GetComponent<Image>();
    }

    public void DoImage(bool state)
    {
        if (uiImage != null)
        {

            if (state)
            {
                uiImage.sprite = succesImage;
            }
            else
            {
                uiImage.sprite = failedImage;
            }
        }
    }
    public void DoColor(bool state)
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
    public void ChangeColor(bool state)
    {
        if (useImage)
            DoImage(state);
        else
            DoColor(state);
    }


}
