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


    // Use this for initialization
    void Start () {
        StartCoroutine(GiveGold());
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
