using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;


public class NetworkPlayer : NetworkBehaviour
{
    [SerializeField] private Transform camera;
    private Transform spawnPoint;

    public override void OnNetworkSpawn()
    {
        this.spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
        this.transform.position = spawnPoint.position;

        if (!IsOwner)
        {
            GetComponentInChildren<CharacterController>().enabled = false;
            GetComponentInChildren<CameraController>().enabled = false;
            GetComponentInChildren<PlayerAnimationController>().enabled = false;
            Destroy(camera.gameObject);
        }
    }
}
