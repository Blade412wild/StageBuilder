using SharpOSC;
using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class OSCManager : MonoBehaviour
{
    [Header("UI Target Device UI")]
    public TMP_InputField TargetIPField;
    public TMP_InputField TargetPortField;

    [Header("UI Own Device UI")]
    //public TMP_InputField OwnDeviceIPField;
    public TMP_InputField OwnDevicePortField;

    [Header("UI Data UI")]
    public TMP_InputField chatInput;
    public TMP_InputField chatIncomingData;

    [Header("UI Status")]
    public UIStatusBlock ListenerUIStatus;
    public UIStatusBlock SenderUIStatus;

    [Header("HeadRotation")]
    public HeadTracking HeadTracking;
    public HeadTracking1 HeadTracking1;
    public string Value;
    public string Value2;
    private string oscSendMessage;

    // readonly List<>

    private List<ISendableData> DataOuputList = new List<ISendableData>();

    private OSCSender sender;
    private OSCReceiver listener;

    private string incommingData;


    private void Update()
    {
        chatIncomingData.text = incommingData;
        //Value = HeadTracking.TempValue;
        Value = HeadTracking1.TempValue;
        Value2 = HeadTracking1.TempValue2;
    }

    public void CreateUDPSender()
    {
        if (sender != null) return;
        string targetIP = TargetIPField.text;
        int targetPort = Convert.ToInt32(TargetPortField.text);

        sender = new OSCSender(targetIP, targetPort);
        SenderUIStatus.ChangeColor(true);
    }

    public void CreateUDPListener()
    {
        if (listener != null) return;

        int ownPort = Convert.ToInt32(OwnDevicePortField.text);


        listener = new OSCReceiver(ownPort);

        // set event listener
        if (listener != null)
        {
            listener.OndataReceived += CheckIncomingMessage;
        }
        ListenerUIStatus.ChangeColor(true);
    }

    public void SendMessage()
    {
        if (sender == null)
        {
            Debug.Log("create a Sender");
        }
        else
        {
            oscSendMessage = "HeadTracking/1/" + Value + "/" + "HeadTracking/2/" + Value2 + "/";
            //sender.SendMessage("HeadTracking/1", Value);
            //sender.SendMessage("HeadTracking/2", Value2);
            sender.SendMessage("ARGlasses", oscSendMessage);
        }
    }

    private void CheckIncomingMessage(string value)
    {
        incommingData = value;
    }


    private void DestroyUDPSender()
    {
        sender.CloseSender();
        sender = null;

    }

    private void DestroyUDPListener()
    {
        listener.CloseListener();
        listener = null;
    }

    public void ResetSender()
    {
        if (sender == null) return;
        DestroyUDPSender();
        SenderUIStatus.ChangeColor(false);
    }

    public void ResetListener()
    {
        if (listener == null) return;
        DestroyUDPListener();
        ListenerUIStatus.ChangeColor(false);
    }

    public bool CheckSenderAvailable()
    {
        if (sender == null) return false;
        else return true;
    }
    public bool CheckListenerAvailable()
    {
        if (listener == null) return false;
        else return true;
    }

    public void GetDataOutput()
    {
        //foreach (ISendableData data in DataOuputList)
        //{
        //    data.GetData();
        //}
    }

    private void OnDestroy()
    {
        if (sender != null)
        {
            DestroyUDPSender();
        }

        if (listener != null)
        {
            DestroyUDPListener();
        }
    }
}
