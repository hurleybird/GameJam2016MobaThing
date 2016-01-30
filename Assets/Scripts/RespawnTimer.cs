using System;
using System.Collections.Generic;
using UnityEngine;


public class RespawnTimer : MonoBehaviour
{
    public event Action OnRespawn;

    [SerializeField]
    private float timeRemainingToRespawn;
    private GameObject player;

    public float TimeRemainingToRespawn
    {
        get { return timeRemainingToRespawn; }
    }

    public void Init(float respawnTime, GameObject player)
    {
        timeRemainingToRespawn = respawnTime;
        this.player = player;
    }

    public void Update()
    {
        timeRemainingToRespawn -= Time.deltaTime;

        if (timeRemainingToRespawn <= 0)
        {
            OnRespawn();
            Destroy(this);
        }
    }
}

