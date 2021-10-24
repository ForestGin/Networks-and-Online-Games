using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TMPro;

public class UDPClient : MonoBehaviour
{

    int recv;
    byte[] data;
    String input, stringData;
    IPEndPoint ipep;
    Socket server;
    EndPoint Remote;

    Thread listener = null;
    bool kill = false;

    public TextMeshProUGUI TextBubble;
    bool printpong = false;

    void Start()
    {

        data = new byte[1024];
        ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);//Defining local IP

        server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        
        

        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
        Remote = (EndPoint)sender;


        if (listener == null)
        {
            listener = new Thread(ListenForMessages);
            listener.Start();

        }

    }

    private void Update()
    {

        if (kill && !listener.IsAlive)
        {

            listener = null;
            Debug.Log("Thread closed");
            TextBubble.text = "Thread closed\n";
            kill = false;
            server.Close();
        }

        if (printpong == true)
        {
            TextBubble.text += "Pong" + "\n";
            printpong = false;
        }
    }


    void ListenForMessages()
    {


        try
        {

            String welcome = "Waiting for the server..";
            data = Encoding.ASCII.GetBytes(welcome);
            server.SendTo(data, data.Length, SocketFlags.None, ipep);


            data = new byte[1024];
            int recv = server.ReceiveFrom(data, ref Remote);

            Debug.Log("Message recieve form:" + Remote.ToString());
            Debug.Log(Encoding.ASCII.GetString(data, 0, recv));



            int i = 0;

            while (!kill)
            {

                server.SendTo(Encoding.ASCII.GetBytes("Ping"), Remote);
                data = new byte[1024];
                recv = server.ReceiveFrom(data, ref Remote);
                stringData = Encoding.ASCII.GetString(data, 0, recv);
                Debug.Log(stringData);
                i++;
                Thread.Sleep(1000);
                printpong = true;
                if (i == 5)
                {

                    RequestKillThread();

                }

            }


            Debug.Log("Disconnecting from server...");
            server.Shutdown(SocketShutdown.Both);
            server.Close();

           
        }
        catch (ThreadInterruptedException exception)
        {

            Debug.Log("thread Interrupted");
            RequestKillThread();


        }
    }

    void RequestKillThread()
    {
        kill = true;
    }

}
