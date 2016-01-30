using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private float damage = 1;

    private Team team;

    public void Init (Team _team)
    {
        team = _team;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
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
