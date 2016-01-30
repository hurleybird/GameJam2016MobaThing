using UnityEngine;
using UnityEngine.UI;

public class AbilityCDGfx : MonoBehaviour {

    private Image icon;
    [SerializeField]
    private Ability ability;

	// Use this for initialization
	void Start () {
        GetComponent<Image>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        icon.fillAmount = ability.GetCooldownProgress();
	}
}
