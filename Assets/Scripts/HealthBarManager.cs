using UnityEngine;
using System.Collections;

public class HealthBarManager : Singleton<HealthBarManager> {

    [SerializeField]
    private Transform team1Spawn;
    [SerializeField]
    private Transform team2Spawn;
    [SerializeField]
    private GameObject healthPrefab;

    public void CreateHealthBar(Health health)
    {
        GameObject newObj = Instantiate(healthPrefab);
        newObj.transform.SetParent(team1Spawn, false);
        newObj.GetComponent<HealthBar>().Init(health);

        newObj = Instantiate(healthPrefab);
        newObj.transform.SetParent(team2Spawn, false);
        newObj.GetComponent<HealthBar>().Init(health);
    }

}
