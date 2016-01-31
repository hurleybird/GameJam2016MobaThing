using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    [SerializeField]
    private float shopRange;
    [SerializeField]
    private GameObject shopUI;
    [SerializeField]
    private GameObject shopPrompt;
    [SerializeField]
    private Player player;
    [SerializeField]
    private Team team;
    private string prefix = "";

    void Start()
    {
        if (player.Side == Allignment.Blue)
            prefix = "Player2";
    }

    public void Update()
    {
        shopPrompt.SetActive(false);
        if (Vector3.Distance(player.transform.position, transform.position) <= shopRange)
        {
            player.GetComponent<Health>().TakeHealing(40 * Time.deltaTime);
            if (!shopUI.activeInHierarchy)
            {
                shopPrompt.SetActive(true);
            }
            if (Input.GetButtonDown(prefix + "Start"))
            {
                if (shopUI.activeInHierarchy)
                    shopUI.SetActive(false);
                else
                    shopUI.SetActive(true);
            }
        }
        else
        {
            shopUI.SetActive(false);
        }
    }
}
