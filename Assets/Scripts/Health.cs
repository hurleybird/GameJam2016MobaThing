using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    [SerializeField]
    private float regenRate;
    [SerializeField]
    private float maxHealth;
    private float currentHealth;
	
    public float MaxHealth(){ return maxHealth; }
    public float CurrentHealth() { return currentHealth; }

    void Start()
    {
        currentHealth = maxHealth;
        HealthBarManager.Instance.CreateHealthBar(this);
    }

    void Update()
    {
       currentHealth += regenRate * Time.deltaTime;

       if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
            Kill();
    }

    void Kill()
    {

    }

}
