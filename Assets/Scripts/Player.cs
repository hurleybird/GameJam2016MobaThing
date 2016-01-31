using UnityEngine;
using System.Collections.Generic;

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

    public List<Ability> Abilities { get; private set; }

    public Team Team { get { return _team; } }

    public Allignment Side { get { return side; } } 

    void Awake()
    {
        Abilities = new List<Ability>();
        Abilities.Add(aa);
        Abilities.Add(ability1);
        Abilities.Add(ability2);
    }

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
