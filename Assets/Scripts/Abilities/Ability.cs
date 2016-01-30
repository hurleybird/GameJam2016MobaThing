using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField]
    protected Transform spawnPoint;
    [SerializeField]
    protected GameObject toSpawn;
    [SerializeField]
    protected float cooldown;
    protected float timeLeft = 0;

    public float GetCooldownProgress()
    {
        float wait = (cooldown - timeLeft) * (1 / cooldown);
        return (wait > 0 ? wait : 0);
    }

    void Update()
    {
        if (timeLeft > 0)
            timeLeft -= Time.deltaTime;
    }

    virtual public void Activate()
    {
        if (timeLeft > 0)
            return;
        else
        {
            timeLeft = cooldown;
            Fire();
        }
    }

    public void Fire()
    {
        GameObject newObj = Instantiate(toSpawn, spawnPoint.position, transform.rotation) as GameObject;
        newObj.gameObject.layer = gameObject.layer + 2;
        FireSecondPart();
    }
    protected abstract void FireSecondPart();


}
