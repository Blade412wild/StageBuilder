using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zTestMusic : MonoBehaviour
{

    public float BPM;
    public float seconds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        seconds = ConvertBPMTOSeconds.ConvertBPMToSeconds(BPM);
    }
}
