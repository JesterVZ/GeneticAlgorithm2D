using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    public static int[] commandList;
    void Start()
    {
        commandList = new int[16];
        for(int i = 0; i < commandList.Length; i++)
        {
            commandList[i] = Random.Range(1, 9);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void ShowElementsOsArray()
    {
        for(int i = 0; i < commandList.Length; i++)
        {
            Debug.Log(commandList[i]);
        }
        Debug.Log("===================================================================");
    }
}
