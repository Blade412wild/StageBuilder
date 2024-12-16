using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static  class ConvertBPMTOSeconds
{
    public static float ConvertBPMToSeconds(float bps)
    {
        float totalseconds = 60000f;
        int beats = 4;

        float seconds = ((totalseconds / bps) * beats) / 1000;
        return seconds;
    }
}
