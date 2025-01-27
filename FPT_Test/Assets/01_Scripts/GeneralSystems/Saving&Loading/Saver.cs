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
            // data path in editor
            path = Application.dataPath + fileName + ".txt";
        }
        else
        {
            // data path in built
            path = Application.persistentDataPath + fileName + ".txt";
        }

        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(JsonUtility.ToJson(data));
        writer.Close(); // eerst sluiten
        writer.Dispose(); // daarna disposen, als je dit niet doet krijg je dataleaks
    }
}
