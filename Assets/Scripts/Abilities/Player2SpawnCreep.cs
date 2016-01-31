using UnityEngine;
using System.Collections.Generic;

public class Player2SpawnCreep : Ability
{
    [SerializeField]
    private List<Transform> Waypoints = new List<Transform>();

    protected override void FireSecondPart(GameObject newObj, Team team)
    {
        newObj.layer = gameObject.layer;
        newObj.GetComponent<Renderer>().material = GetComponent<Renderer>().material;
        Creep newCreep = newObj.GetComponent<Creep>();
        newCreep.Init(Waypoints, team);
    }
}
