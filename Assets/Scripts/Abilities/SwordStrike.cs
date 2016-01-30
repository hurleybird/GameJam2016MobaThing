using UnityEngine;
using System.Collections;

public class SwordStrike : Ability
{
    public override void Activate()
    {
        if (timeLeft > 0)
            return;
        else
        {
            timeLeft = cooldown;
            Fire();
        }
    }

    void Fire()
    {
        GameObject newObj = Instantiate(toSpawn, spawnPoint.position, transform.rotation) as GameObject;
        newObj.gameObject.layer = gameObject.layer + 2;
    }
}
