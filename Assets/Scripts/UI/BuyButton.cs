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

    void LateUpdate()
    {
        button.interactable = false;
        int? cost = team.GetCost(toUpgrade);
        if (cost != null && team.Monies >= cost)
            button.interactable = true;

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
                text.text = "Maxed";
                break;
        }
    }
}
