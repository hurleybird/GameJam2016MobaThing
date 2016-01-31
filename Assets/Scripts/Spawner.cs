using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    [SerializeField]
    private Team _team;
    [SerializeField]
    private GameObject creepFab;
    [SerializeField]
    private Transform spawnTrans;
    [SerializeField]
    private List<Transform> waypoints = new List<Transform>();
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
        GameObject newObj = Instantiate(creepFab, spawnTrans.position, Quaternion.identity) as GameObject;
        newObj.layer = gameObject.layer;
        newObj.GetComponent<Renderer>().material = GetComponent<Renderer>().material;
        Creep newCreep = newObj.GetComponent<Creep>();
        newCreep.Init(waypoints, _team);
        timeLeft = spawnDelay;
    }
}
