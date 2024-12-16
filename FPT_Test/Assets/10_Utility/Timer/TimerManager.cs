using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    private static TimerManager instance;
    public List<Timer> ActiveTimersList = new List<Timer>();
    public List<Timer> waitingTimerList = new List<Timer>();
    public List<Timer> waitingRemoveList = new List<Timer>();
    public List<Timer> ActiveTimerRemoveList = new List<Timer>();
    public static TimerManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject newTimeManger = new GameObject();
                TimerManager timeManager = newTimeManger.AddComponent<TimerManager>();
                newTimeManger.transform.name = "TimeManager";
                instance = timeManager;
            }

            return instance;
        }

    }

    // Update is called once per frame
    void Update()
    {

        // adding the timers from the waiting list to the activeList
        foreach (Timer timer in waitingTimerList)
        {
            ActiveTimersList.Add(timer);
            waitingRemoveList.Add(timer);
        }

        // Remove every timer in the waiting list 
        foreach (Timer timer in waitingRemoveList)
        {
            waitingTimerList.Remove(timer);
        }

        waitingRemoveList.Clear();

        // update the active TimerList
        foreach (Timer timer in ActiveTimersList)
        {
            timer.OnUpdate();
        }

        // remove the timer from the activeList 
        foreach (Timer timer in ActiveTimerRemoveList)
        {
            ActiveTimersList.Remove(timer);
        }

        // clearing the remove
        ActiveTimerRemoveList.Clear();
    }


    public void RemoveTimerFromList(Timer _timer)
    {
        ActiveTimerRemoveList.Add(_timer);
    }

    public void AddTimerToList(Timer _timer)
    {
        _timer.OnRemoveTimer += RemoveTimerFromList;
        waitingTimerList.Add(_timer);
        //ActiveTimersList.Add(_timer);
    }
}
