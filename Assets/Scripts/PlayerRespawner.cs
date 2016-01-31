using System;
using UnityEngine;
using System.Collections.Generic;


public class PlayerRespawner : MonoBehaviour
{
    [SerializeField]
    private GameObject leftPlayer; // Red
    [SerializeField]
    private GameObject rightPlayer; // Blue

    [SerializeField]
    private GameObject leftPlayerRespawn;
    [SerializeField]
    private GameObject rightPlayerRespawn;

    [SerializeField]
    private RespawnTimerUI leftPlayerUI;
    [SerializeField]
    private RespawnTimerUI rightPlayerUI;



    public void Start()
    {
        ConnectToOnKilledEvent(leftPlayer);
        ConnectToOnKilledEvent(rightPlayer);
    }

    private void ConnectToOnKilledEvent(GameObject player)
    {
        var healthComponent = player.GetComponent<Health>();
        healthComponent.OnKilled += Respawn;
    }

    private void Respawn(GameObject player)
    {
        var playerAllignemnt = GetPlayerAlignment(player);

        switch (playerAllignemnt)
        {
            case Allignment.Blue:
                RespawnPlayer(player, rightPlayerRespawn, rightPlayerUI);
                break;

            case Allignment.Red:
                RespawnPlayer(player, leftPlayerRespawn, leftPlayerUI);
                break;
        }
    }

    private Allignment GetPlayerAlignment(GameObject player)
    {
        return player.GetComponent<Player>().Side;
    }

    private void RespawnPlayer(GameObject player, GameObject respawnLocation, RespawnTimerUI playerUIObject)
    {
        player.transform.position = respawnLocation.transform.position;
        var playerRespawnerTimer = gameObject.AddComponent<RespawnTimer>();
        playerUIObject.Init(playerRespawnerTimer);

        playerRespawnerTimer.OnRespawn += () => player.SetActive(true);

        var respawnTime = CalculateRespawnTime();
        playerRespawnerTimer.Init(respawnTime, player);
        player.GetComponent<Health>().Reset();
        player.SetActive(false);
    }

    private float CalculateRespawnTime()
    {
        // TODO: Do calculations here to determine respawn time for player
        return 10.0F;
    }


}

