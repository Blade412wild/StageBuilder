using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDynamicHeightScaler : MonoBehaviour
{
    public bool CalculateScales = false;
    private RectTransform transform;

    [SerializeField] private float newYpos;
    [SerializeField] private float newHeight;

    [SerializeField] private float oldYpos;
    [SerializeField] private float oldHeight;

    private void Start()
    {
        transform = GetComponent<RectTransform>();
        oldYpos = transform.localPosition.y;
        oldHeight = transform.sizeDelta.y;

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
}
