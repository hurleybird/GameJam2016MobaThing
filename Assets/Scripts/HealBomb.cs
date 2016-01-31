using UnityEngine;
using System.Collections;

public class HealBomb : MonoBehaviour {

    private LayerMask mask;
    [SerializeField]
    private float lifeTime = 3.5f;

	// Use this for initialization
	void Start () {
        mask = gameObject.layer -= 2;
	}
	
	// Update is called once per frame
	void Update () {

        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
            Destroy(gameObject);

        RaycastHit[] hits = Physics.SphereCastAll(transform.position, 5f, Vector3.forward, 1 << 9);

        foreach (RaycastHit hit in hits)
        {
            Health hitHealth = hit.transform.GetComponent<Health>();
            if (hitHealth != null)
            {
                if (!hit.transform.GetComponent<Tower>() && ! hit.transform.GetComponent<Spawner>()) //would be OP on structures
                    hitHealth.TakeHealing(100f * Time.deltaTime);
            }
        }

    }
}
