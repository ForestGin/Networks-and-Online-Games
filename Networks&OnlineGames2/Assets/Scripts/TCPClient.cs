using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TMPro;

public class TCPClient : MonoBehaviour
{
    byte[] data;
    String stringData;
    IPEndPoint ipep;
    Socket server;
    int recv;

    Thread listener;

    public TextMeshProUGUI TextBubble;
    bool printpong = false;

    void Start()
    {

        data = new byte[1024];
        ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
        server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        listener = null;

        try
        {

            server.Connect(ipep);
            Debug.Log("Connected with server");
            TextBubble.text = "Connected with server\n";
            listener = new Thread(Listen);
            listener.Start();

        }
        catch (SocketException e)
        {

            Debug.Log("Unable to connect to server.");
            TextBubble.text = "Unable to connect to server\n";
            Debug.Log(e.ToString());
            return;
        }


    }


    void Update()
    {
        if (printpong == true)
        {
            TextBubble.text += "Pong" + "\n";
            printpong = false;
        }
    }

    void Listen()
    {

        recv = server.Receive(data);
        stringData = Encoding.ASCII.GetString(data, 0, recv);
        Debug.Log(stringData);

        int i = 0;
        while (true)
        {

            if (i >= 5)
            {
                break;
            }

            server.Send(Encoding.ASCII.GetBytes("Ping"));
            data = new byte[1024];
            recv = server.Receive(data);
            stringData = Encoding.ASCII.GetString(data, 0, recv);
            printpong = true;
            Debug.Log(stringData);
            i++;
            Thread.Sleep(1000);
        }

        Debug.Log("Disconnecting from server...");
        server.Shutdown(SocketShutdown.Both); 
        server.Close();



    }

    void OnApplicationQuit()
    {

        Debug.Log("Application ending after " + Time.time + " seconds");

    }
}
