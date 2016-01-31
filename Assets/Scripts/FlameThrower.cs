using UnityEngine;
using System.Collections;

public class FlameThrower : MonoBehaviour
{
    [SerializeField]
    private Transform center;
    private LayerMask mask;
    [SerializeField]
    private float lifeTime = 3.8f;
    private Team team;

    public void Init(Team _team)
    {
        team = _team;
    }

    // Use this for initialization
    void Start()
    {
        mask = gameObject.layer -= 1;
    }

    // Update is called once per frame
    void Update()
    {

        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
            Destroy(gameObject);

        RaycastHit[] hits = Physics.BoxCastAll(center.position, new Vector3(4.5f, 2.5f, 2.5f), Vector3.forward, Quaternion.identity, 8f, 1 << 9);

        foreach (RaycastHit hit in hits)
        {
            Health hitHealth = hit.transform.GetComponent<Health>();
            if (hitHealth != null)
            {
                if (!hit.transform.GetComponent<Tower>() && !hit.transform.GetComponent<Spawner>()) //would be OP on structures
                    if (hitHealth.TakeDamage(66f * team.GetAttackMult() * Time.deltaTime))
                        team.Monies += hitHealth.MoniesToGive();
            }
        }

    }
}