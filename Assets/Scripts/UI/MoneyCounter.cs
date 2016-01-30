using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour {

    [SerializeField]
    private Text text;
    [SerializeField]
    private Team team;

	void LateUpdate ()
    {
        text.text = team.Monies + " Gold";
	}
}
