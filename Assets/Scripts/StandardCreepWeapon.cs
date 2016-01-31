using System;
using System.Collections.Generic;
using UnityEngine;

public class StandardCreepWeapon : MonoBehaviour
{
    private const int team1Layer = 1 << 8;
    private const int team2Layer = 1 << 9;

    [SerializeField]
    private Ability ability;

    [SerializeField]
    private Creep creepLogic;

    [SerializeField]
    private LayerMask enemyLayer;

    public void Start()
    {
        creepLogic.OnTargetInRange += OnHaveTargetToFireAt;
        enemyLayer = GetEnemyLayer();
    }

    private LayerMask GetEnemyLayer()
    {
        if (gameObject.layer == team1Layer)
            return team2Layer;
        return team1Layer;
    }

    public void OnHaveTargetToFireAt(Transform targetPoint)
    {
        if (HaveClearShotAtTarget(targetPoint))
        {
            FireProjectile();
        }
    }

    private bool HaveClearShotAtTarget(Transform targetPoint)
    {
        return Physics.Raycast(transform.position, transform.forward, 9000F, enemyLayer);
    }

    private void FireProjectile()
    {
        ability.Activate(creepLogic.Team);
    }
}
