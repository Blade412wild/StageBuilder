using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicPanel", menuName = "Music/MusicPanel", order = 1)]
public class MusicPanel : ScriptableObject
{
    public List<AudioClip> audioClips;
}
