using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SharpOSC;


public class NewOSCTest : MonoBehaviour
{
    OscBundle bundle;
    string test = "hallo";
    UDPListener listener;
    UDPSender Sender;

    OSCReceiver OSCReceiver;
    OSCSender OSCSender;

    UDPListener listenerNew;

    string gerben= "192.168.2.202";
    string ik = "192.168.2.235";
    string hans = "192.168.2.193";





    // Start is called before the first frame update
    void Start()
    {
        //CreateUDPReceiver();
        CreateUDPSender(hans, 9000);
        CreateOSCReceiver(54001);
        //OSCSender = new OSCSender(ik, 9002);
       //CreateNewUDPListner();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OscTest();
        }
        //StartListening();
    }

    private void OscTest()
    {
        var message1 = new OscMessage("/test1", 23, 42.01f, test);
        var message2 = new OscMessage("/test2", 32, 50);
        var bundle = new OscBundle(100, message1, message2);

        Sender.Send(bundle);
        //OSCSender.SendMessage("192.168.2.235", test);


        //Debug.Log("bundle send : " + bundle.Messages.ToString());
    }
    private void CreateOSCReceiver(int port)
    {
        OSCReceiver = new OSCReceiver(port);
    }

    private void CreateUDPReceiver(int port)
    {
        listener = new UDPListener(port);
    }

    private void CreateUDPSender(string ip, int port)
    {
        //Sender = new UDPSender("196.168.2.202", 9002);
        Sender = new UDPSender(ip, port);
    }
    public void Main(string[] args)
    {
        // The cabllback function
        HandleOscPacket callback = delegate (OscPacket packet)
        {
            var messageReceived = (OscMessage)packet;
            Debug.Log("Received a message!");
        };

        var listener = new UDPListener(9002, callback);

        //Debug.Log("Press enter to stop");
        listener.Close();
    }

    static void Main2(string[] args)
    {
        var listener = new UDPListener(55555);
        OscMessage messageReceived = null;
        while (messageReceived == null)
        {
            messageReceived = (OscMessage)listener.Receive();
            //Thread.Sleep(1);
        }
        //Console.WriteLine("Received a message!");
    }

    private void OnDisable()
    {
        //listener.Dispose();
        //istener.Close();
        OSCReceiver.CloseListener();
        Sender.Close();

    }

    private void CreateNewUDPListner()
    {

        // The cabllback function
        HandleOscPacket callback = delegate (OscPacket packet)
        {
            var messageReceived = (OscMessage)packet;
            Debug.Log("Received a message! new OSC");
        };

        listenerNew = new UDPListener(9000, callback);

    }
}
