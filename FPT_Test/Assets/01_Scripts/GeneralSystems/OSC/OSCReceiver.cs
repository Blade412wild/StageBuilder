using UnityEngine;
using SharpOSC;
using System.Threading; // For threading
using System;

public class OSCReceiver
{
    public Action<string> OndataReceived;

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

    // This method listens for incoming OSC messages
    public void StartListening()
    {
        isListening = true; // Set the flag to true when starting

        // Run the listener on a new thread to avoid blocking the main Unity thread
        listenerThread = new Thread(() =>
        {
            while (isListening) // Continue while listening is true
            {
                var packet = listener.Receive();
                if (packet != null && packet is OscMessage message)
                {
                    // Extract the OSC message data and handle it
                    string address = message.Address;
                    string receivedValue = message.Arguments[0].ToString();
                    //incommingData = message.Arguments[0].ToString();
                    //Debug.Log("OSC Message received. Address: " + address + ", Value: " + receivedValue);

                    // Process the received OSC message
                    ProcessOSCMessage(address, receivedValue);
                }
            }
        });

        listenerThread.Start(); // Start the thread
    }

    // Custom method to handle OSC messages
    private void ProcessOSCMessage(string address, string value)
    {
        // Example: If the message address is "/example", trigger an event in Unity

        Debug.Log("Processing OSC message with value: " + value);
        OndataReceived?.Invoke(value);
        // Perform actions in Unity based on OSC message

    }

    public void CloseListener()
    {
        // Stop listening and wait for the thread to finish
        if (listenerThread != null && listenerThread.IsAlive)
        {
            // Set the flag to false to stop the thread loop
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