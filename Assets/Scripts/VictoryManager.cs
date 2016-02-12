using UnityEngine;
using System.Collections;

public class VictoryManager : MonoBehaviour {

    [SerializeField]
    private GameOver gameOver;
    [SerializeField]
    private Spawner team1Spawn;
    [SerializeField]
    private Spawner team2Spawn;
	
	// Update is called once per frame
	void Update () {

        if (team1Spawn == null)
            gameOver.EndGame("Blue Wins!", Color.blue);
        else if (team2Spawn == null)
            gameOver.EndGame("Red Wins!", Color.red);
;	
	}
}
