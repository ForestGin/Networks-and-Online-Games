using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class UDPServer : MonoBehaviour
{
    private int recv;
    private byte[] data;
    private Thread listener = null;
    private Socket socket;
    private IPEndPoint ipep;
    private EndPoint remote;
    String input, stringData;

    bool kill = false;


    void Start()
    {
        data = new byte[1024];
        ipep = new IPEndPoint(IPAddress.Any, 9050);//local IP
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        socket.Bind(ipep);
        /*String starting =*/
        Debug.Log("Waiting for the Client...");
        //data = Encoding.ASCII.GetBytes(starting);
        //socket.SendTo(data, data.Length, SocketFlags.None, ipep);

        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
        remote = (EndPoint)sender;

        if (listener == null)
        {
            listener = new Thread(Listen);
            listener.Start();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (kill && !listener.IsAlive)
        {

            listener = null;
            Debug.Log("Thread closed");
            kill = false;
            socket.Close();
        }
    }

    void Listen()
    {
        try
        {
            data = new byte[1024];
            int recv = socket.ReceiveFrom(data, ref remote);
            Debug.Log("Message recieve form:" + remote.ToString());
            Debug.Log(Encoding.ASCII.GetString(data, 0, recv));

            int i = 0;

            while (!kill)
            {
                socket.SendTo(Encoding.ASCII.GetBytes("Pong"), remote);
                data = new byte[1024];
                recv = socket.ReceiveFrom(data, ref remote);
                stringData = Encoding.ASCII.GetString(data, 0, recv);
                Debug.Log(stringData);
                i++;
                Thread.Sleep(1000);

                if (i == 5)
                {
                    RequestKillThread();
                }
            }

        }
        catch (ThreadInterruptedException exception)
        {

            Debug.Log("Thread Interrupted");
            RequestKillThread();


        }

    }

    void RequestKillThread()
    {
        kill = true;

    }


}
