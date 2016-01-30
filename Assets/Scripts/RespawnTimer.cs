using System;
using System.Collections.Generic;
using UnityEngine;


public class RespawnTimer : MonoBehaviour
{
    public event Action OnRespawn;

    [SerializeField]
    private float _timeRemainingToRespawn;
    private GameObject player;

    public float TimeRemainingToRespawn
    {
        get { return _timeRemainingToRespawn; }
    }

    public void Init(float respawnTime, GameObject player)
    {
        _timeRemainingToRespawn = respawnTime;
        this.player = player;
    }

    public void Update()
    {
        _timeRemainingToRespawn -= Time.deltaTime;

        if (_timeRemainingToRespawn <= 0)
        {
            OnRespawn();
            Destroy(this);
        }
    }
}

