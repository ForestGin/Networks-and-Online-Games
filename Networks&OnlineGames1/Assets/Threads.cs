using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class Threads : MonoBehaviour
{

    GameObject CubeObject;

    Vector3 pos;
    float movement_speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        CubeObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
    }

    // Update is called once per frame
    void Update()
    {
        
        lock(CubeObject)
        {
            CubeObject.transform.position = pos;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Key Down");

            Thread myThread = new Thread(MoveObject);
            myThread.Start();     
            
            Debug.Log("Finished Key Down");
        }

    }
    

    public void MoveObject()
    {
        Debug.LogWarning("Starting Moving Thread");
        System.DateTime myTime;

        Vector3 speed = new Vector3(0f, 0f, 2f);

        myTime = System.DateTime.UtcNow;
        while((System.DateTime.UtcNow-myTime).Seconds < 5f)
        {
            //translate object
            lock (CubeObject)
            {
                pos += Vector3.forward * movement_speed;
            }
            
        }

        Debug.Log("5s passed");

        Debug.Log("Finished Thread");
    }

    
}
