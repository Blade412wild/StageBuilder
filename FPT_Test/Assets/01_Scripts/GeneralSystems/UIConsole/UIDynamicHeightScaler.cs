using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDynamicHeightScaler : MonoBehaviour
{
    public bool CalculateScales = false;

    [SerializeField] private float newYpos;
    [SerializeField] private float newHeight;

    [SerializeField] private float oldYpos;
    [SerializeField] private float oldHeight;

    private RectTransform transform;
    private VerticalLayoutGroup verticalLayoutGroup;
    [SerializeField] private float spacing;

    private void Start()
    {
        transform = GetComponent<RectTransform>();
        verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
        oldYpos = transform.localPosition.y;
        oldHeight = transform.sizeDelta.y;

        spacing = verticalLayoutGroup.spacing;


    }

    private void Update()
    {
        if (CalculateScales)
        {
            newYpos = oldYpos - (newHeight / 2) + (oldHeight/2);
            
            transform.localPosition = new Vector3(transform.localPosition.x, newYpos);

            transform.sizeDelta = new Vector2(transform.sizeDelta.x, newHeight);

            CalculateScales = false;
        }
    }

    public void CalculateNewYPos(float newHeight)
    {
        newYpos = oldYpos - (newHeight / 2) + (oldHeight / 2);

        transform.localPosition = new Vector3(transform.localPosition.x, newYpos);

        transform.sizeDelta = new Vector2(transform.sizeDelta.x, newHeight);

        CalculateScales = false;
    }
}
