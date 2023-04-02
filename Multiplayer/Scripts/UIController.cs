using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button hostButton;
    [SerializeField] private Button connectButton;
    [SerializeField] private TextMeshProUGUI ipText;

    private void Start()
    {
        hostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
            OnStartGame();
        });

        connectButton.onClick.AddListener(() =>
        {
            // For some reason, ipText.text has an extra character. 
            // We only want to connect with entered IP if we have one that is entered.
            if (ipText.text.Length > 1)
            {
                string newIp = ipText.text.Substring(0, ipText.text.Length - 1);
                NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(
                    newIp,
                    (ushort)7777,
                    "0.0.0.0"
                );
            }

            NetworkManager.Singleton.StartClient();
            OnStartGame();

        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Cursor.visible = !Cursor.visible;
        }
    }

    private void OnStartGame()
    {
        this.GetComponent<Canvas>().enabled = false;
        Cursor.visible = false;
    }
}
