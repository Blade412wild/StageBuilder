using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Saver
{
    public Saver()
    {

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
}
