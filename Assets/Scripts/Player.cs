using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField]
    private Allignment side;
    [SerializeField]
    private Ability ability1;
    [SerializeField]
    private Ability ability2;

    public Allignment Side { get { return side; } }

    public void FireAbility1()
    {
        ability1.Activate();
    }
    public void FireAbility2()
    {
        ability2.Activate();
    }
}
