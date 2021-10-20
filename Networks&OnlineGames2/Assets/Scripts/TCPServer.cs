using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class TCPServer : MonoBehaviour
{
    private int recv;
    private byte[] data;
    private Thread listener = null;
    private Socket socket;
    private IPEndPoint ipep;
    String stringData;
    int BacklogClientQueue;
    int PingPongIteration;

    void Start()
    {
        data = new byte[1024];
        ipep = new IPEndPoint(IPAddress.Any, 9050);//local IP
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.Bind(ipep);
        BacklogClientQueue = 5;
        socket.Listen(BacklogClientQueue);
        PingPongIteration = 5;//Times the client and server will send Ping/Pong communication
        Debug.Log("Waiting for the Client...");
       
        //start the thread
        if (listener == null)
        {
            listener = new Thread(ListenMessages);
            listener.Start();
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void ListenMessages()
    {
        try
        {
            for (int i = 0; i < BacklogClientQueue; i++)
            {

                Socket client = socket.Accept(); //the new socket cannot be use again to Accept the next queue connection 
                IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;//Socket.RemoteEndPoint return a object Endpoint with the IP and port number

                Debug.Log("Connected with " + clientep.Address + "at port " + clientep.Port);

                String welcome = "Starting communication";
                data = Encoding.ASCII.GetBytes(welcome);
                client.Send(data, data.Length, SocketFlags.None);


                int z = 0;

                while (z < PingPongIteration)
                {
                    data = new byte[1024];
                    recv = client.Receive(data);//blocks
                    if (recv == 0)
                    {//if client send 0 byte lenght data then disconnect  

                        break;

                    }
                    stringData = Encoding.ASCII.GetString(data, 0, recv);
                    Debug.Log(stringData);
                    client.Send(Encoding.ASCII.GetBytes("Pong"), SocketFlags.None);
                    z++;
                    Thread.Sleep(1000);

                }

                Debug.Log("Disconnected from: " + clientep.Address);
                client.Close();


            }
            socket.Close();

        }
        catch
        {
            Debug.Log("Thread interrumpted closing connection");
            socket.Close();

        }

    }   

    void OnApplicationQuit()
    {       
        Debug.Log("Application ending after " + Time.time + " seconds");
    }
}