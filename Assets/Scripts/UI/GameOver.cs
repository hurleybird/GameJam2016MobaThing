using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameOver : Singleton<GameOver> {

    [SerializeField]
    private Text text;
    [SerializeField]
    private GameObject endGameScreen;

	public void EndGame(string message, Color color)
    {
        text.text = message;
        text.color = color;
        endGameScreen.SetActive(true);
        StartCoroutine(Finish());
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene("Menu");
    }

    IEnumerator Finish()
    {
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("Menu");
    }
}
