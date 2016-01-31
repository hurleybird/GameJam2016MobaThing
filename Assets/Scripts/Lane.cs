using UnityEngine;
using System.Collections.Generic;

public class Lane : MonoBehaviour
{
    [SerializeField]
    private Transform _spawnTrans;
    [SerializeField]
    private List<Transform> _waypoints = new List<Transform>();

    public Transform SpawnTrans { get { return _spawnTrans; } }
    public List<Transform> Waypoints {  get { return _waypoints; } }
}
