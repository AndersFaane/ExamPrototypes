using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public AudioSource gameOverSFX;

    //public AIChase aiChase;
   

    public void gameOver()
    {
        
        gameOverUI.SetActive(true);
        gameOverSFX.Play();
        
        //aiChase.GetComponent<AIChase>().enabled = false;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //aiChase.GetComponent<AIChase>().enabled = true;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void quit()
    {
        Application.Quit();
    }
}
