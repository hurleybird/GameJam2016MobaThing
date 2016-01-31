using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

    [SerializeField]
    private Team _team;
    [SerializeField]
    private float turnRate;
    [SerializeField]
    private Ability towerAA;
    private LayerMask mask;

    public Team Team { get { return _team; } }

    void Start()
    {
        if (gameObject.layer == 8)
            mask = 1 << 9;
        else
            mask = 1 << 8;
    }

    void Update()
    {
        Transform aggro = null;
        RaycastHit[] hits = Physics.BoxCastAll(transform.position, new Vector3(13,13,13), Vector3.forward, Quaternion.identity, 100f, mask.value);

        float minDistance = float.MaxValue;

        if (hits.Length != 0)
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

        if (aggro == null)
            return;

        Quaternion prevRotation = transform.rotation;
        transform.LookAt(aggro);
        transform.rotation = Quaternion.Slerp(prevRotation, transform.rotation, Time.deltaTime * turnRate);
        towerAA.Activate(_team);

    }
}
