using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

    [SerializeField]
    private Team _team;
    [SerializeField]
    private Ability towerAA;

    public Team Team { get { return _team; } }
	
	//void Update () {
 //       aggro = null;
 //       RaycastHit[] hits = Physics.BoxCastAll(transform.position, new Vector3(6, 6, 6), Vector3.forward, Quaternion.identity, 100f, mask.value);

 //       float minDistance = float.MaxValue;

 //       if (hits.Length == 0)
 //       {
 //           aggro = null;
 //       }
 //       else
 //       {
 //           foreach (RaycastHit hit in hits)
 //           {
 //               float distance = Vector3.Distance(transform.position, hit.transform.position);
 //               if (distance < minDistance)
 //               {
 //                   minDistance = distance;
 //                   aggro = hit.transform;
 //               }
 //           }
 //       }

 //   }
}
