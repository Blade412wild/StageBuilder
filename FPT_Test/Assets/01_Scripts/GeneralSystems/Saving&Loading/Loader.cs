using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static Saver;

public class Loader : MonoBehaviour
{
    public T LoadData<T>(string fileName)
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

        if (File.Exists(path) == false) return default;

        StreamReader streamReader = new StreamReader(path);

        T data2 = JsonUtility.FromJson<T>(streamReader.ReadToEnd());
        streamReader.Close();
        streamReader.Dispose();

        return data2;
    }
}
