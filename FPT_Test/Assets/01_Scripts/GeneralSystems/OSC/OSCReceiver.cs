using UnityEngine;
using SharpOSC;
using System.Threading; // For threading
using System;
using System.Collections.Generic;

public class OSCReceiver
{
    public Action<string> OndataReceived;
    public Action OnConnectionMade;
    public Action OnConnectionTestReceived;

    private UDPListener listener;
    private int port; // Listening port
    private Thread listenerThread; // The background thread for listening
    private bool isListening = false; // Flag to control thread execution
    public string incommingData;


    public OSCReceiver(int port)
    {
        this.port = port;
        CreateUDPListener();
        StartListening();
    }

    private void CreateUDPListener()
    {
        listener = new UDPListener(port);
        Debug.Log("OSC Receiver initialized on Port: " + port);
    }

    public void StartListening()
    {
        isListening = true;

        listenerThread = new Thread(() =>
        {
            while (isListening) // Continue while listening is true
            {
                var packet = listener.Receive();

                if (packet != null && packet is OscBundle bundle)
                {
                    ProcessOSCMessage(bundle);
                }
            }
        });

        listenerThread.Start();
    }

    private void ProcessOSCMessage(OscBundle bundle)
    {
        foreach (OscMessage oscMessage in bundle.Messages)
        {

            //Debug.Log(oscMessage.Address);

            for (int i = 0; i < oscMessage.Arguments.Count; i++)
            {
                //Debug.Log(oscMessage.Address + " : " + oscMessage.Arguments[i].ToString());

                if (oscMessage.Address == "ConnectionValue") // deze naam moet worden verstuurd vanuit de DAW
                {
                    if (oscMessage.Arguments[0].GetType() != typeof(int)) return; // het fhoeft niet per se een int te zijn, is vooral voor zekerheid van het bericht, naam zou al genoeg kunnen zijn.
                    if ((int)oscMessage.Arguments[0] != 0) return;
                    OnConnectionMade?.Invoke();
                }
            }
        }
    }

    public void CloseListener() // deze moet eigenlijk altijd gecalled worden bij het sluiten van de applicatie of wanneer er een nieuwe IP config wordt aangemaakt
    {
        // Stop listening and wait for the thread to finish
        if (listenerThread != null && listenerThread.IsAlive)
        {
            isListening = false;

            // Close the UDPListener to stop receiving new messages
            if (listener != null)
            {
                listener.Close();
                Debug.Log("OSC Listener closed.");
            }

            // Wait for the thread to exit
            listenerThread.Join();
            Debug.Log("OSC Listener thread has been stopped.");
        }
    }
}