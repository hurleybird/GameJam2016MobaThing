using UnityEngine;
using System.Collections.Generic;

public enum Upgrade : int { None = 0, One = 1, Two = 2, Three = 3 }
public enum UpgradeType : int { Attack = 0, Health = 1, Speed = 2 }

public class Team : MonoBehaviour {

    [SerializeField]
    private Allignment _side;
    public List<capturable> ObjectivesHeld { get; set; }
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

    public void Init()
    {
        Upgrades = new List<Upgrade>();
        Upgrades.Add(new Upgrade());
        Upgrades.Add(new Upgrade());
        Upgrades.Add(new Upgrade());

        Monies = 0;
        ObjectivesHeld = new List<capturable>();
    }

    public void BuyAttack()
    {
        Upgrades[(int)UpgradeType.Attack]++;
    }

    public void BuyHealth()
    {
        Upgrades[(int)UpgradeType.Health]++;
    }

    public void BuySpeed()
    {
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
        else if (Upgrades[(int)type] == Upgrade.One)
        {
            return 300;
        }
        else return null;
    }
}
