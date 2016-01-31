using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    [SerializeField]
    float rotateSpeedX;
    [SerializeField]
    float rotateSpeedY;
    [SerializeField]
    float rotateSpeedZ;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotateSpeedX * Time.deltaTime, rotateSpeedY * Time.deltaTime, rotateSpeedZ * Time.deltaTime);
	}
}
