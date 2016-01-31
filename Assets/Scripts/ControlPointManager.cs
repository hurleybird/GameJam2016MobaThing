using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlPointManager : MonoBehaviour {

    [SerializeField]
    private List<Capturable> cPoints = new List<Capturable>();
    [SerializeField]
    private Team team1;
    [SerializeField]
    private Team team2;

    [SerializeField]
    private Transform team1Spawn;
    [SerializeField]
    private Transform team2Spawn;
    [SerializeField]
    private GameObject progressPrefab;

    // Use this for initialization
    void Start () {
        StartCoroutine(GiveGold());
        foreach (Capturable cPoint in cPoints)
        {
            CreateHealthBar(cPoint);
        }
	}

    public void CreateHealthBar(Capturable cPoint)
    {
        GameObject newObj = Instantiate(progressPrefab);
        newObj.transform.SetParent(team1Spawn, false);
        newObj.GetComponent<ProgressBar>().Init(cPoint);

        newObj = Instantiate(progressPrefab);
        newObj.transform.SetParent(team2Spawn, false);
        newObj.GetComponent<ProgressBar>().Init(cPoint);
    }

    // Update is called once per frame
    void Update () {
	
	}

    IEnumerator GiveGold()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            foreach (Capturable cPoint in cPoints)
            {
                if (cPoint.Team != null)
                    cPoint.Team.Monies++;
            }
        }
    }
}
