using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class HeadTracking1 : MonoBehaviour
{
    [SerializeField] private Material minLimit;
    [SerializeField] private Material maxLimit;
    [SerializeField] private Transform indicatorTransform;
    [SerializeField] private HeadRotationLimit sphereLimit;

    [SerializeField] private TMPro.TMP_Text UIoutputV;
    [SerializeField] private TMPro.TMP_Text UIoutputH;

    private float maxValue = 127.0f;
    private float minValue = 0f;
    private float dotProductV;
    private float dotProductH;
    private Vector3 lockVector3;


    Vector3[] angles = new Vector3[2];
    int counter = 0;
    List<HeadRotationLimit> rotationLimits = new List<HeadRotationLimit>();

    // even voor vrijdag
    public string TempValue = "0";
    public string TempValue2 = "0";

    // Update is called once per frame
    void Update()
    {
        dotProductV = CalculateDotProduct(Vector3.up);

        if (lockVector3 != null)
        {
            dotProductH = CalculateDotProduct(lockVector3);
        }

        UpdateLimitPositions();

        if (counter >= 2)
        {
            float value = MapData(dotProductV, rotationLimits[0].dotProduct, rotationLimits[1].dotProduct);
            string outputValue = FormatUIOutput(value, UIoutputV);
            TempValue = outputValue;
        }

        if(counter >= 4)
        {
            float value = MapData(dotProductH, rotationLimits[2].dotProduct, rotationLimits[3].dotProduct);
            string outputValue = FormatUIOutput(value, UIoutputH);
            TempValue2 = outputValue;
        }

    }

    private string FormatUIOutput(float value, TMPro.TMP_Text uiOutput)
    {
        string formattedOutput = $"{value:F2}";
        //TempValue = formattedOutput;
        uiOutput.text = formattedOutput;
        return formattedOutput;
    }

    private float MapData(float dotProduct, float minProduct, float maxProduct)
    {
        float value = CalculateNewValueInNewScale(dotProduct, minProduct, maxProduct, minValue, maxValue);

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


    private float CalculateDotProduct(Vector3 axis)
    {
        float dotProduct = Vector3.Dot(axis, transform.forward);
        return dotProduct;
    }

    private void UpdateLimitPositions()
    {
        if (rotationLimits.Count < 4) return;

        foreach (HeadRotationLimit limit in rotationLimits)
        {
            if (limit.index == 0 || limit.index == 1)
            {
                Vector3 RelativePostion = new Vector3(indicatorTransform.transform.position.x, limit.transform.position.y, indicatorTransform.transform.position.z);
                limit.transform.position = RelativePostion;
            }
            if (limit.index == 2 || limit.index == 3)
            {
                Vector3 RelativePostion = new Vector3(limit.transform.position.x, indicatorTransform.transform.position.y, limit.transform.position.z);
                limit.transform.position = RelativePostion;
            }
        }
    }

    public void AddRotationValue()
    {
        if (counter < 4)
        {
            if (counter >= 4) return;

            HeadRotationLimit limit = Instantiate(sphereLimit, indicatorTransform.position, Quaternion.identity);
            rotationLimits.Add(limit);

            if (counter == 0)
            {
                rotationLimits[counter].GetComponent<MeshRenderer>().material = minLimit;
                limit.index = 0;
                limit.dotProduct = dotProductV;

            }
            else if (counter == 1)
            {
                rotationLimits[counter].GetComponent<MeshRenderer>().material = maxLimit;
                limit.index = 1;
                limit.dotProduct = dotProductV;
            }
            else if (counter == 2)
            {
                rotationLimits[counter].GetComponent<MeshRenderer>().material = minLimit;
                limit.index = 2;
                limit.dotProduct = dotProductH;
            }
            else if (counter == 3)
            {
                rotationLimits[counter].GetComponent<MeshRenderer>().material = maxLimit;
                limit.index = 3;
                limit.dotProduct = dotProductH;
            }
            counter++;

        }
        else if (counter == angles.Length)
        {
            counter++;
        }
    }

    public void LockVector()
    {
        lockVector3 = new Vector3(transform.right.x, transform.right.y, transform.right.z);
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
