using UnityEngine;
using UnityEngine.UI;
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

    [SerializeField]
    private GameObject countdownObj;
    [SerializeField]
    private Text count;
    [SerializeField]
    private int timeLimit;
    private int timeLeft;

    // Use this for initialization
    void Start () {
        timeLeft = timeLimit;
        StartCoroutine(GiveGold());
        StartCoroutine(RitualVictory());
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

    IEnumerator RitualVictory ()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (cPoints.TrueForAll(x => x.Team == team1))
            {
                if (timeLeft == 0)
                {
                    GameOver.Instance.EndGame("Red Wins!", Color.red);
                    yield break;
                }
                countdownObj.SetActive(true);
                timeLeft--;
                count.color = Color.red;
                count.text = timeLeft.ToString();

            }
            else if (cPoints.TrueForAll(x => x.Team == team1))
            {
                if (timeLeft == 0)
                {
                    GameOver.Instance.EndGame("Blue Wins!", Color.blue);
                    yield break;
                }
                countdownObj.SetActive(true);
                timeLeft--;
                count.color = Color.blue;
                count.text = timeLeft.ToString();
            }
            else
            {
                countdownObj.SetActive(false);
                timeLeft = timeLimit;
            }
            
        }


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
