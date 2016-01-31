using System;
using UnityEngine;
using System.Collections.Generic;

public class Creep : MonoBehaviour {

    private List<Transform> waypoints = new List<Transform>();
    private int waypointIndex = 0;
    [SerializeField]
    private Ability attack;
    [SerializeField]
    private float movementRate;
    [SerializeField]
    private float turnRate;
    private LayerMask mask;
    private Transform aggro;
    private Transform target;
    private Rigidbody rBody;

    public Team Team { get; set; }

    public void Init(List<Transform> _waypoints, Team _team)
    {
        waypoints = _waypoints;
        Team = _team;
    }

    void Start()
    {
        rBody = GetComponent<Rigidbody>();

        if (gameObject.layer == 8)
            mask = 1<<9;
        else
            mask = 1<<8;
    }

    void FixedUpdate()
    {

        aggro = null;
        RaycastHit[] hits = Physics.BoxCastAll(transform.position, new Vector3(10, 10, 10), Vector3.forward, Quaternion.identity, 100f, mask.value);

        float minDistance = float.MaxValue;

        if (hits.Length == 0)
        {
            aggro = null;
        }
        else
        {
            foreach (RaycastHit hit in hits)
            {
                float distance = Vector3.Distance(transform.position, hit.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    aggro = hit.transform;
                }
            }
        }
        if (aggro != null)
        {
            target = aggro;
            attack.Activate(Team);
        }
        else
            target = waypoints[waypointIndex];

        Quaternion prevRotation = transform.rotation;
        transform.LookAt(target);
        transform.rotation = Quaternion.Slerp(prevRotation, transform.rotation, Time.deltaTime * turnRate);

        float targetDistance = Vector3.Distance(transform.position, target.position);

        if (aggro != null && targetDistance > 5f)
            rBody.AddForce(transform.forward * movementRate * Team.GetSpeedMult());
        else if (aggro == null && targetDistance > 1f)
            rBody.AddForce(transform.forward * movementRate * Team.GetSpeedMult());
        else if (waypointIndex < waypoints.Count - 1)
        {
            waypointIndex++;
        }
    }
}
