using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLooper : MonoBehaviour
{

    [SerializeField] private List<MusicBox> list = new List<MusicBox>();
    private Timer timer;
    private int counter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartLoop()
    {
        if (timer != null) return;
        timer = new Timer(0.25f, true);
        timer.OnTimerIsDone += PlayNextSound;
    }

    public void StopLoop()
    {
        counter = 0;
        timer.RemoveTimer();
    }
    private void PlayNextSound()
    {
        if (counter == list.Count)
        {
            counter = 0;
        }

        list[counter].Source.Play();
        Debug.Log(list[counter].name + " playSound");

        counter++;
    }
}
