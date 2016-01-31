using UnityEngine;
using System.Collections;

public class Modulo : MonoBehaviour {

	public static float Mod(float a,float b)
	{
		return a - b * Mathf.Floor(a / b);
	}
}
