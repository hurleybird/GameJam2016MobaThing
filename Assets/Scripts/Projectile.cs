using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private float damage = 1;
    [SerializeField]
    private float range = 5.0F;

    public float Range { get { return range; } }

    private float remainingDistance;
    private Team team;

    public void Start()
    {
        remainingDistance = range;
    }

    public void Init (Team _team)
    {
        team = _team;
    }
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        float movementThisUpdate = speed * Time.deltaTime;
        remainingDistance -= movementThisUpdate;
        if (remainingDistance <= 0)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector3.forward * movementThisUpdate);
        
	}

    void OnTriggerEnter(Collider other)
    {
        Health hitHealth = other.GetComponent<Health>();
        if (hitHealth != null)
        {
            if (hitHealth.TakeDamage(damage))
            {
                Debug.Log(team != null);
                team.Monies += hitHealth.MoniesToGive();
            }
        }
        Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
