using UnityEngine;

[CreateAssetMenu(menuName = "Messages/CustomMessage", fileName = "CustomError", order = 0)]
public class CustomError2 : ScriptableObject
{
    public enum TypeMessage { FatalError, Recommondation }

    [TextAreaAttribute(minLines: 3, maxLines: 6)]
    public string ShortMessage;
    [TextAreaAttribute]
    public string DetailedMessage = "...";

    public TypeMessage type;
}
