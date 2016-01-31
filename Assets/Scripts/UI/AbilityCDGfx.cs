using UnityEngine;
using UnityEngine.UI;

public class AbilityCDGfx : MonoBehaviour {

    private Image icon;
    [SerializeField]
    private Player player;
    [SerializeField]
    private int abilityNum;

    private Ability ability;

	// Use this for initialization
	void Start () {
        icon = GetComponent<Image>();
        ability = player.Abilities[abilityNum];
	}
	
	// Update is called once per frame
	void LateUpdate () {
        icon.fillAmount = ability.GetCooldownProgress();
	}
}
