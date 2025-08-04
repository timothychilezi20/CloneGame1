using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    public GameObject player;
    public Transform playerSpawner;
 

    private void Start()
    {
        spawnPlayer();
    }

    public void spawnPlayer()
    {
        if(player!=null && playerSpawner != null)
        {
            Instantiate(player, playerSpawner.position, playerSpawner.rotation);
        }
        else
        {
            Debug.LogError("Player or Spawnpoint not assigned");
        }
    }
}

