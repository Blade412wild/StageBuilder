using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class HeadTracking : MonoBehaviour
{
    [SerializeField] private Material minLimit;
    [SerializeField] private Material maxLimit;
    [SerializeField] private Transform indicatorTransform;
    [SerializeField] private HeadRotationLimit sphereLimit;

    [SerializeField] private TMPro.TMP_Text UIoutput;

    private float maxValue = 127.0f;
    private float minValue = 0f;
    private float dotProduct;


    Vector3[] angles = new Vector3[2];
    int counter = 0;
    List<HeadRotationLimit> rotationLimits = new List<HeadRotationLimit>();

    // even voor vrijdag
    public string TempValue = "0";



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dotProduct = CalculateDotProduct();
        UpdateLimitPositions();

        if (counter >= 2)
        {
            float value = MapData();
            FormatUIOutput(value);

        }

    }

    private void FormatUIOutput(float value)
    {
        string formattedOutput = $"{value:F2}";
        TempValue = formattedOutput;
        UIoutput.text = formattedOutput;
    }

    private float MapData()
    {
        float value = CalculateNewValueInNewScale(dotProduct, rotationLimits[0].dotProduct, rotationLimits[1].dotProduct, minValue, maxValue);

        if (value > maxValue)
        {
            value = maxValue;
        }
        else if (value < minValue)
        {
            value = minValue;
        }
        return value;
    }


    public static float CalculateNewValueInNewScale(float valueOldScale, float oldMin, float oldMax, float newMin, float newMax)
    {
        float newValue = (valueOldScale - oldMin) / (oldMax - oldMin) * (newMax - newMin) + newMin;


        return newValue;
    }


    private float CalculateDotProduct()
    {
        float dotProduct = Vector3.Dot(Vector3.up, transform.forward);
        return dotProduct;
    }

    private void UpdateLimitPositions()
    {
        foreach (HeadRotationLimit limit in rotationLimits)
        {
            Vector3 RelativePostion = new Vector3(indicatorTransform.transform.position.x, limit.transform.position.y, indicatorTransform.transform.position.z);
            limit.transform.position = RelativePostion;
        }
    }

    public void AddRotationValue()
    {
        if (counter < 2)
        {
            if (counter >= 2) return;

            HeadRotationLimit limit = Instantiate(sphereLimit, indicatorTransform.position, Quaternion.identity);
            rotationLimits.Add(limit);

            if (counter == 0)
            {
                rotationLimits[counter].GetComponent<MeshRenderer>().material = minLimit;
                limit.index = 0;
                limit.dotProduct = dotProduct;

            }
            else
            {
                rotationLimits[counter].GetComponent<MeshRenderer>().material = maxLimit;
                limit.index = 1;
                limit.dotProduct = dotProduct;
            }
            counter++;

        }
        else if (counter == angles.Length)
        {
            counter++;
        }
    }

    private void addValue()
    {
        if (counter < angles.Length)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SetMiddleRotation();
            }
            Debug.Log("transform.forward : " + transform.forward);
        }
        else if (counter == angles.Length)
        {
            Debug.Log("vector1 : " + angles[0] + ", " + "vector2 : " + angles[1]);
            counter++;
        }
    }


    private void SetMiddleRotation()
    {
        if (counter >= angles.Length) return;
        angles[counter] = transform.forward;
        counter++;

    }


}
