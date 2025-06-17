using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{

    public GameObject tutorialUi;

    public GameObject menuUi;
    public void LoadSceneByName()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void ShowTutorial()
    {
        tutorialUi.SetActive(true);
        menuUi.SetActive(false);
    }
    public void quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        tutorialUi.SetActive(false);
        menuUi.SetActive(true);
    }
}
