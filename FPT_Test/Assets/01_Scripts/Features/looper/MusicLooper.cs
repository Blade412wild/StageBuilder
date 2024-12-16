using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLooper : MonoBehaviour
{
    public float BPM;
    public float seconds;

    [SerializeField] private List<MusicBox> list = new List<MusicBox>();

    private Timer timer;
    private int counter = 0;
    private bool isPLaying;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        //seconds = ConvertBPMTOSeconds.ConvertBPMToSeconds(BPM);
    }

    public void StartLoop()
    {
        if (isPLaying == true) return;
        isPLaying = true;
        timer = new Timer(seconds, true);
        timer.OnTimerIsDone += PlayNextSound;
    }

    public void StopLoop()
    {
        if(isPLaying == false) return;
        counter = 0;
        timer.RemoveTimer();
        isPLaying = false;
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
