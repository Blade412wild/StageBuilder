using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Saver
{
    public Action<IDataAccess> OnSaveData;

    private DataTestObject dataObject;

    public Saver()
    {
        //OnSaveData += SaveData;

        dataObject = new DataTestObject()
        {
            FileName = "DataTestWow",
            Position = new Vector3(0, 1, 0),
            Rotation = new Vector3(0, 90, 0),
            height = 10
        };

    }

    public void SaveData(DataTestObject data)
    {
        string path;

        if (Application.isEditor)
        {
            path = Application.dataPath + data.FileName + ".txt";
        }
        else
        {
            path = Application.persistentDataPath + data.FileName + ".txt";
        }


        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(JsonUtility.ToJson(data));
        writer.Close();
        writer.Dispose();
    }

    public void LoadData(DataTestObject data)
    {
        string path = data.FileName;

        if (Application.isEditor)
        {
            path = Application.dataPath + data.FileName + ".txt";
        }
        else
        {
            path = Application.persistentDataPath + data.FileName + ".txt";
        }

        if (File.Exists(path) == false) return;

        StreamReader streamReader = new StreamReader(path);

        DataTestObject data2 = JsonUtility.FromJson<DataTestObject>(streamReader.ReadToEnd());
        streamReader.Close();
        streamReader.Dispose();

        Debug.Log(data2.Position);
    }


    public struct DataTestObject
    {
        public string FileName;
        public Vector3 Position;
        public Vector3 Rotation;
        public int height;
    }
}
