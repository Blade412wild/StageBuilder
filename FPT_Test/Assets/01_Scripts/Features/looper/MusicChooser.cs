using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChooser : MonoBehaviour
{
    public event Action OnTestMusic;
    public event Action<AudioClip> OnSetClip;

    public AudioClip Clip;

    public void PlayAudioTest()
    {
        OnTestMusic?.Invoke();
    }

    public void SetClip()
    {
        OnSetClip?.Invoke(Clip);
    }
}
