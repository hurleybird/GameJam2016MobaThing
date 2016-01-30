using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {


    [SerializeField]
    private Transform toFollow;

	void LateUpdate()
    {
        transform.position = new Vector3(toFollow.position.x, transform.position.y, toFollow.position.z);
    }
}
