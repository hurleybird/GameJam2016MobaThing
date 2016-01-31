using UnityEngine;
using System.Collections;

public class Player1FlameThrow : Ability
{
    protected override void FireSecondPart(GameObject newObj, Team team)
    {
        newObj.GetComponent<FlameThrower>().Init(team);
        newObj.transform.SetParent(transform);
    }
}
