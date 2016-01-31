using System;
using UnityEngine;
using System.Collections;

public class Capturable : MonoBehaviour 
{
    public event Action OnAllignmentChange;

    [SerializeField]
    private Material neutralMat;
    [SerializeField]
    private Material team1Mat;
    [SerializeField]
    private Material team2Mat;
    [SerializeField]
    private Player player1;
    [SerializeField]
    private Player player2;
    [SerializeField]
    private float captureDistance;
    [SerializeField]
    private float captureTrigger;

	public Team Team { get; private set; }

	private float capturePoints = 0;

    private Renderer rend;

    public float CaptureTrigger() { return captureTrigger; }
    public float CapturePoints() { return capturePoints; }

    void Start()
    {
        rend = GetComponent<Renderer>();
    }


    void Update()
    {
        Vector3 player1Pos = player1.transform.position;
        Vector3 player2Pos = player2.transform.position;
        Vector3 thisPos = transform.position;
        float distancePlayer1 = Vector3.Distance(new Vector3(thisPos.x, 0, thisPos.z), new Vector3(player1Pos.x, 0, player1Pos.z));
        float distancePlayer2 = Vector3.Distance(new Vector3(thisPos.x, 0, thisPos.z), new Vector3(player2Pos.x, 0, player2Pos.z));
        bool player1Caping = distancePlayer1 <= captureDistance;
        bool player2Caping = distancePlayer2 <= captureDistance;

        if (player1Caping && !player2Caping)
        {
            capturePoints -= Time.deltaTime;
        }
        else if (player2Caping && !player1Caping)
        {
            capturePoints += Time.deltaTime;
        }
        else if (player1Caping && player2Caping)
        {
            if (capturePoints < 0)
            {
                capturePoints += Time.deltaTime / 2.5f;
            }
            else if (capturePoints > 0)
            {
                capturePoints -= Time.deltaTime / 2.5f;
            }
        }
        else
        {
            if (Team == player1.Team && capturePoints > -captureTrigger)
            {
                capturePoints -= Time.deltaTime / 3f;
            }
            else if (Team == player2.Team && capturePoints < captureTrigger)
            {
                capturePoints -= Time.deltaTime / 3f;
            }
            else if (Team == null && capturePoints < 0)
            {
                capturePoints += Time.deltaTime;
                if (capturePoints > 0)
                    capturePoints = 0;
            }
            else if (Team == null && capturePoints > 0)
            {
                capturePoints -= Time.deltaTime;
                if (capturePoints > 0)
                    capturePoints = 0;
            }
        }

        if (capturePoints >= captureTrigger)
        {
            Team = player2.Team;
            OnAllignmentChange();
        }
        else if (capturePoints <= -captureTrigger)
        {
            Team = player1.Team;
            OnAllignmentChange();
        }
        else if (capturePoints > -0.01f && capturePoints < 0.01f)
        {
            Team = null;
        }


        if (Team == player1.Team)
        {
            rend.material = team1Mat;
        }
        else if (Team == player2.Team)
        {
            rend.material = team2Mat;
        }
        else
        {
            rend.material = neutralMat;
        }

        if (capturePoints > captureTrigger)
            capturePoints = captureTrigger;
        else if (capturePoints < -captureTrigger)
            capturePoints = -captureTrigger;
    }




 //   void Awake()
 //   {
 //       Init();
 //   }

 //   public void Init()
 //   {
 //       remainingCapturePoints = capturePoints;
 //   }

 //   // Update is called once per frame
 //   void Update () 
	//{
	//	if (beingCapturedBy != Allignment.None) 
	//	{
	//		capturePoints -= currentCapturer.captureRate * Time.deltaTime;
	//		if (capturePoints < 0) {
	//			//_allignment = beingCapturedBy;
	//			capturePoints = 10.0F;
	//		}
	//	}

	//}
	//private void capture()
	//{

	//}
	//private void OnGameTriggerEnter(Collider other)
	//{
	//	var foundCapturer = other.GetComponent<capturer>();

	//	if (foundCapturer != null) 
	//	{
	//		var foundAllignment = other.GetComponent<Allignment> ();
	//		//if (foundAllignment != _allignment) 
	//		{
	//			beingCapturedBy = foundAllignment;
 //               currentCapturer = foundCapturer;
	//		}
	//	}
	//}

}
