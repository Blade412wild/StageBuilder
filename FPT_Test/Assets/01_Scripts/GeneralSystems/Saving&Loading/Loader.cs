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
            // data path voor wanneer in editor
            path = Application.dataPath + fileName + ".txt";
        }
        else
        {
            // data path voor wanneer in built
            path = Application.persistentDataPath + fileName + ".txt";
        }

        if (File.Exists(path) == false) return default;

        StreamReader streamReader = new StreamReader(path);

        T data2 = JsonUtility.FromJson<T>(streamReader.ReadToEnd());
        streamReader.Close(); // belangrijk om altijd eerst te sluiten.
        streamReader.Dispose();// nu kan je hem disposen, anders krijg je dataleaks

        return data2;
    }
}
