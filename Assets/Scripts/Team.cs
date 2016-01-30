using UnityEngine;
using System.Collections.Generic;

public enum Upgrade : int { None, One, Two, Three }

public class Team : MonoBehaviour {

    [SerializeField]
    private Allignment _side;
    public List<capturable> ObjectivesHeld { get; set; }
    public Upgrade PlayerHealth { get; set; }
    public Upgrade PlayerAttack { get; set; }
    public Upgrade PlayerSpeed { get; set; }
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
        Monies = 0;
        ObjectivesHeld = new List<capturable>();
        PlayerHealth = Upgrade.None;
        PlayerAttack = Upgrade.None;
        PlayerSpeed = Upgrade.None;
    }
}
