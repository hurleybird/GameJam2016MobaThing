using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private float damage = 1;

    void Awake ()
    {
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
            hitHealth.TakeDamage(damage);
        }
        Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
