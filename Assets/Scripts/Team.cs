using UnityEngine;
using System.Collections.Generic;

public enum Upgrade : int { None = 0, One = 1, Two = 2, Three = 3 }
public enum UpgradeType : int { Attack = 0, Health = 1, Speed = 2 }

public class Team : MonoBehaviour {

    [SerializeField]
    private HealthBarManager _hBarMan;
    public HealthBarManager HBarMan {  get { return _hBarMan; } }
    [SerializeField]
    private Allignment _side;
    public List<Capturable> ObjectivesHeld { get; set; }
    public List<Upgrade> Upgrades { get; set; }
    public int Monies { get; set; }

    public Allignment Side
    {
        get { return _side; }
    }

    void Awake()
    {
        Init();
    }

    public float GetAttackMult()
    {
        return 1f + (0.33f * (int)Upgrades[0]);
    }

    public float GetDefenseMult()
    {
        return 1f + (0.36f * (int)Upgrades[1]);
    }

    public float GetSpeedMult()
    {
        return 1f + (0.2f * (int)Upgrades[2]);
    }

    public void Init()
    {
        Upgrades = new List<Upgrade>();
        Upgrades.Add(new Upgrade());
        Upgrades.Add(new Upgrade());
        Upgrades.Add(new Upgrade());

        Monies = 0;
        ObjectivesHeld = new List<Capturable>();
        Monies = 0;
    }

    public void BuyAttack()
    {
        Monies -= (int)GetCost(UpgradeType.Attack);
        Upgrades[(int)UpgradeType.Attack]++;
    }

    public void BuyHealth()
    {
        Monies -= (int)GetCost(UpgradeType.Health);
        Upgrades[(int)UpgradeType.Health]++;
    }

    public void BuySpeed()
    {
        Monies -= (int)GetCost(UpgradeType.Speed);
        Upgrades[(int)UpgradeType.Speed]++;
    }

    public int? GetCost(UpgradeType type)
    {
        if (Upgrades[(int)type] == Upgrade.None)
        {
            return 100;
        }
        else if (Upgrades[(int)type] == Upgrade.One)
        {
            return 200;
        }
        else if (Upgrades[(int)type] == Upgrade.Two)
        {
            return 300;
        }
        else return null;
    }
}
