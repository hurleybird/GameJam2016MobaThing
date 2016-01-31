using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour {

    [SerializeField]
    private UpgradeType toUpgrade;
    [SerializeField]
    private Team team;
    private Button button;
    private Text text;

    void Awake()
    {
        button = GetComponent<Button>();
        text = GetComponentInChildren<Text>();
    }

    void Update()
    {
        switch (team.Upgrades[(int)toUpgrade])
        {
            case Upgrade.None:
                text.text = "Tier 1 (100 gold)";
                break;
            case Upgrade.One:
                text.text = "Tier 2 (200 gold)";
                break;
            case Upgrade.Two:
                text.text = "Tier 3 (300 gold)";
                break;
            case Upgrade.Three:
                text.text = "Tier 4 (400 gold)";
                break;
            case Upgrade.Four:
                text.text = "Tier 5 (500 gold)";
                break;
            case Upgrade.Five:
                text.text = "Maxed";
                break;
        }
        button.interactable = false;
        int? cost = team.GetCost(toUpgrade);
        if (cost != null && team.Monies >= cost)
            button.interactable = true;
    }
}
