using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Saver
{
    private DataTestObject dataObject;

    public Saver()
    {

        dataObject = new DataTestObject()
        {
            FileName = "DataTestWow",
            Position = new Vector3(0, 1, 0),
            Rotation = new Vector3(0, 90, 0),
            height = 10
        };

    }

    public void SaveData<T>(T data, string fileName)
    {
        string path;

        if (Application.isEditor)
        {
            path = Application.dataPath + fileName + ".txt";
        }
        else
        {
            path = Application.persistentDataPath + fileName + ".txt";
        }


        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(JsonUtility.ToJson(data));
        writer.Close();
        writer.Dispose();
    }

    public struct DataTestObject
    {
        public string FileName;
        public Vector3 Position;
        public Vector3 Rotation;
        public int height;
    }
}
