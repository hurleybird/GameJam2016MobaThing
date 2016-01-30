using UnityEngine;
using System.Collections;

public class capturable : MonoBehaviour 
{
	private Allignment _allignment;

	public SphereCollider captureRadius;
	public float capturePoints = 10.0F;
	private float remainingCapturePoints = capturePoints;

	private Allignment beingCapturedBy = Allignment.None;
	private capturer currentCapturer;

	// Use this for initialization
	void Start () 
	{
		_allignment = GetComponent<Allignment ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (beingCapturedBy != Allignment.None) 
		{
			capturePoints -= currentCapturer.captureRate * Time.deltaTime;
			if (capturePoints < 0) {
				_allignment = beingCapturedBy;
				capturePoints = 10.0F;
			}
		}

	}
	private void capture()
	{

	}
	private void OnGameTriggerEnter(Collider other)
	{
		var foundCapturer = other.GetComponent<capturer>();

		if (foundCapturer != null) 
		{
			var foundAllignment = other.GetComponent<Allignment> ();
			if (foundAllignment != _allignment) 
			{
				beingCapturedBy = foundAllignment;
				capturer = GetComponent<capturer> ();
			}
		}
	}

}
