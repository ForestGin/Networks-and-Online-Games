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

    int recv;
    byte[] data;
    IPEndPoint ipep;
    Socket socket;
    int num_connections;
    // Start is called before the first frame update
    void Start()
    {
        data = new byte[1024];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
