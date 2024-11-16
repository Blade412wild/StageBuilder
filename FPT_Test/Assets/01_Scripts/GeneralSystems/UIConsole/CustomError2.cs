using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Messages", fileName = "CustomError", order = 0)]
public class CustomError2 : ScriptableObject
{
    [TextAreaAttribute(minLines: 3, maxLines: 6)]
    public string ShortMessage;
    [TextAreaAttribute]
    public string DetailedMessage;

    public Image Icon;
}
