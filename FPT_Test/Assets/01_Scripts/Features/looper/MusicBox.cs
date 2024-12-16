using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicBox : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip clip;
    public List<MusicChooser> musicChooserList = new List<MusicChooser>();

    private void Awake()
    {
        Source = GetComponent<AudioSource>();
       
    }
    private void Start()
    {
        SetEvents();
    }

    private void SetEvents()
    {
        foreach(MusicChooser chooser in musicChooserList)
        {
            chooser.OnTestMusic += PlaySound;
            chooser.OnSetClip += SetClip;
        }
    }

    private void PlaySound()
    {
        Source.Play();
    }

    private void SetClip(AudioClip clip)
    {
        Debug.Log("set clip");
        Debug.Log(clip.ToString());
        this.clip = clip;
        Source.clip = clip;
    }

    public void OpenInteraction()
    {

    }

    public void CloseInteraction()
    {

    }

    public void ShowStartButton()
    {

    }
}
