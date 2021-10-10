using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class Threads : MonoBehaviour
{   

    
   
    bool killCube = false;
    bool isAlive = false;
    GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
         

        if (Input.GetMouseButtonDown(0) && !isAlive)
        {
            Debug.Log("Click");          

            
            cube = SpawnCube();
            Thread myThread = new Thread(KillCube);
            myThread.Start();        
                       
                   
        }

        if(isAlive)
            cube.transform.Translate(Vector3.forward * Time.deltaTime);

        if (killCube)
        {
            Destroy(cube);
            
        }

    }
    
    GameObject SpawnCube()
    {
        Debug.Log("Spawning Cube");
        killCube = false;
        isAlive = true;
        return GameObject.CreatePrimitive(PrimitiveType.Cube);
    }

    public void KillCube()
    {
        Debug.LogWarning("Starting Kiling Thread");
        System.DateTime myTime;

       

        myTime = System.DateTime.UtcNow;
        while ((System.DateTime.UtcNow - myTime).Seconds < 5f)
        {
           
          
        }

        Debug.Log("5s passed");
        isAlive = false;
        killCube = true;

        Debug.Log("Finished Thread");        
    }


}
