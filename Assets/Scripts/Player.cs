using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField]
    private Team _team;
    [SerializeField]
    private Allignment side;
    [SerializeField]
    private Ability aa;
    [SerializeField]
    private Ability ability1;
    [SerializeField]
    private Ability ability2;

    public Team Team { get { return _team; } }

    public Allignment Side { get { return side; } } 

    public void FireAA()
    {
        aa.Activate(_team);
    }

    public void FireAbility1()
    {
        ability1.Activate(_team);
    }
    public void FireAbility2()
    {
        ability2.Activate(_team);
    }
}
