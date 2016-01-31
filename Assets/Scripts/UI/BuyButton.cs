using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour {

    [SerializeField]
    private UpgradeType toUpgrade;
    [SerializeField]
    private Team team;
    private Button button;

    void LateUpdate()
    {
        button.interactable = false;
        int? cost = team.GetCost(toUpgrade);
        if (cost != null && team.Monies >= cost)
            button.interactable = true;
    }
}
