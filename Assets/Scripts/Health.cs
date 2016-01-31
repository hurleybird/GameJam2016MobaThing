using System;
using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public event Action<GameObject> OnKilled;

    [SerializeField]
    private float regenRate;
    [SerializeField]
    private float maxHealth;
    private float adjustedMaxHealth;
    private float currentHealth;
    [SerializeField]
    private int moniesToGive = 0;
    private Team team;
	
    public int MoniesToGive() { return moniesToGive; }
    public float MaxHealth(){ return maxHealth; }
    public float CurrentHealth() { return currentHealth; }

    void Start()
    {
        currentHealth = maxHealth;
        adjustedMaxHealth = maxHealth;

        Player player = GetComponent<Player>();
        if (player != null)
        {
            team = player.Team;
        }
        Creep creep = GetComponent<Creep>();
        if (creep != null)
        {
            team = creep.Team;
        }
        Spawner spawner = GetComponent<Spawner>();
        if (spawner != null)
        {
            team = spawner.Team;
        }
        Tower tower = GetComponent<Tower>();
        if (tower != null)
        {
            team = tower.Team;
        }

        team.HBarMan.CreateHealthBar(this);
    }

    void Update()
    {
        float defenseMult = team.GetDefenseMult();
        adjustedMaxHealth = maxHealth * defenseMult;
        currentHealth += regenRate * Time.deltaTime * defenseMult;

        if (currentHealth > adjustedMaxHealth)
            currentHealth = adjustedMaxHealth;
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

    public void TakeHealing(float healing)
    {
        currentHealth += healing;
        if (currentHealth > adjustedMaxHealth)
            currentHealth = adjustedMaxHealth;
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
