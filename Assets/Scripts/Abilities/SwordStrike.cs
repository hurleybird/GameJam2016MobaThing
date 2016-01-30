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

    }
}
