using System;
using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public event Action<GameObject> OnKilled;

    [SerializeField]
    private float regenRate;
    [SerializeField]
    private float maxHealth;
    private float currentHealth;
    [SerializeField]
    private int moniesToGive = 0;
	
    public int MoniesToGive() { return moniesToGive; }
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

    public bool TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            //Kill();
            StartCoroutine(KillSequence());
            return true;
        }
        return false;
    }

    public void Reset()
    {
        currentHealth = maxHealth; 
    }

    IEnumerator KillSequence()
    {
        yield return new WaitForSeconds(0.1f);
        Kill();
    }

    void Kill()
    {
        if (OnKilled != null)
        {
            OnKilled(gameObject);
        }
    }
}
