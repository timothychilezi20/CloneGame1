using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerSpawnPoint : MonoBehaviour
{
    public GameObject player;
    public Transform playerSpawner;
    public CinemachineVirtualCamera playerCamera;
 

    private void Start()
    {
        spawnPlayer();
    }

    public void spawnPlayer()
    {
        if(player!=null && playerSpawner != null)
        {
            player.transform.position = playerSpawner.transform.position;
            playerCamera.Follow = player.transform;
        }
        else
        {
            Debug.LogError("Player or Spawnpoint not assigned");
        }
    }
}

