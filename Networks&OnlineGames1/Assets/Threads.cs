using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class Threads : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Thread myThread = new Thread(TestThread);
        myThread.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TestThread()
    {
        Debug.LogWarning("STARTING THREAD");

        System.DateTime myTime;

        while (!exit)
        {
            myTime = System.DateTime.UtcNow;
            
            while((System.DateTime.UtcNow-myTime).Seconds < 5f)
            {

            }
            Debug.Log("5s passed");
                
        }
    }
}
