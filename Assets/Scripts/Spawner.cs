using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    [SerializeField]
    private Team _team;
    [SerializeField]
    private GameObject creepFab;
    [SerializeField]
    private List<Lane> lanes = new List<Lane>();
    [SerializeField]
    private float spawnDelay = 6f;
    private float timeLeft;

    public Team Team { get { return _team; } }

	// Use this for initialization
	void Start () {
        timeLeft = spawnDelay;
	}
	
	// Update is called once per frame
	void Update () {
        if (timeLeft <= 0)
            Spawn();
        else
            timeLeft -= Time.deltaTime;
	}

    void Spawn()
    {
        foreach (Lane lane in lanes)
        {
            GameObject newObj = Instantiate(creepFab, lane.SpawnTrans.position, Quaternion.identity) as GameObject;
            newObj.layer = gameObject.layer;
            newObj.GetComponent<Renderer>().material = GetComponent<Renderer>().material;
            Creep newCreep = newObj.GetComponent<Creep>();
            newCreep.Init(lane.Waypoints, _team);
            timeLeft = spawnDelay;
        }
    }
}
