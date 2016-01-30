using UnityEngine;


public abstract class Ability : MonoBehaviour
{
    [SerializeField]
    protected float cooldown;
    protected float timeLeft;

    public float GetCooldownProgress()
    {
        float wait = cooldown - timeLeft;
        return 1 - (wait > 0 ? wait : 0);
    }

    void Update()
    {
        if (cooldown > 0)
            cooldown -= Time.deltaTime;

    }

    abstract public void Activate();

}
