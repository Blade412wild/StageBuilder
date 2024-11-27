using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

interface ISendableData
{
    enum DataObject{ Object, Interaction, HeadRotation}

    DataObject dataObject { get; set; }
    int DataOutputs { get; set; }

    void SetDataType();

    void GetData();


}
