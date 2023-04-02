using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class DedicatedServer : MonoBehaviour
{
    void Start()
    {
        string[] args = System.Environment.GetCommandLineArgs();

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "-server")
            {
                NetworkManager.Singleton.StartServer();
            }
        }

        Console.WriteLine("------- STARTING DEDICATED SERVER --------");
        Destroy(this.gameObject);
    }
}
