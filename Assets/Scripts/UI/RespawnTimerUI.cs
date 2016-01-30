using UnityEngine;
using UnityEngine.UI;

public class RespawnTimerUI : MonoBehaviour {

    [SerializeField]
    private Text text;
    [SerializeField]
    private GameObject timerObj;
    private RespawnTimer respawnTimer;
    private bool isActive = false;
	
    public void Init(RespawnTimer _respawnTimer)
    {
        respawnTimer = _respawnTimer;
        timerObj.SetActive(true);
        isActive = true;
    }

	void LateUpdate ()
    {
        if (!isActive)
            return;
        else if (respawnTimer == null)
            isActive = false;
        else if (timerObj.activeInHierarchy)
            text.text = "Respawn in " + (int)respawnTimer.TimeRemainingToRespawn + " seconds";
	}
}
