using UnityEngine;
using UnityEngine.UI;

public class RespawnTimerUI : MonoBehaviour {

    [SerializeField]
    private Text text;
    [SerializeField]
    private GameObject timerObj;
    private RespawnTimer respawnTimer;
	
    public void Init(RespawnTimer _respawnTimer)
    {
        respawnTimer = _respawnTimer;
        timerObj.SetActive(true);
    }

	void LateUpdate ()
    {
        if (respawnTimer == null)
        {
            timerObj.SetActive(false);
            return;
        }
        if (timerObj.activeInHierarchy)
            text.text = "Respawn in " + (int)respawnTimer.TimeRemainingToRespawn + " seconds";
	}
}
