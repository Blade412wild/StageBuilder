using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/PlayerRefs", fileName = "PlayerRefs" )]
public class PlayerRefs : ScriptableObject
{
    [Header("head feature")]
    public Canvas Canvas;
    public HeadTracking HeadTracking;
}
