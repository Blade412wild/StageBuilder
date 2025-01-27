using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SharpOSC;

public class OSCSender
{
    private UDPSender sender;
    private string ipAddress;
    private int port;
    public OSCSender(string ipAddress, int port)
    {
        this.ipAddress = ipAddress;
        this.port = port;

        CreateUDPSender();
    }
    private void CreateUDPSender()
    {
        sender = new UDPSender(ipAddress, port);
        Debug.Log("OSC Sender Initialized on IP: " + ipAddress + " and port: " + port);
    }

    public void SendMessage(OscBundle messagebundle)
    {
        sender.Send(messagebundle);
        //Debug.Log("OSC Message sent to " + ipAddress + ": " + messagebundle);
    }

    public void CloseSender()
    {
        sender.Close();
        Debug.Log("closed Sender");
    }
}
