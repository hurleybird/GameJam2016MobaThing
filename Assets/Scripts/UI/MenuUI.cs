using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour {

    public void NewGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
