using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.VersionControl;

[CreateAssetMenu(menuName = "Messages/CustomMessage", fileName = "CustomError", order = 0)]
public class CustomError2 : ScriptableObject
{
    public enum TypeMessage { Recommondation, FatalError}

    [TextAreaAttribute(minLines: 3, maxLines: 6)]
    public string ShortMessage;
    [TextAreaAttribute]
    public string DetailedMessage = "...";

    public TypeMessage type;
}
