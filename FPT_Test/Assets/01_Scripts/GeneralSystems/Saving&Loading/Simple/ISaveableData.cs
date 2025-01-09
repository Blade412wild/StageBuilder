using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveableData
{
    Saver Saver { get; set; }
    Loader Loader { get; set; }
    string FileName { get; set; }

    void Save();
    void Load();

}
