using UnityEngine;

public class Pause : MonoBehaviour
{
    public PauseGame pauseGame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame.Pause();
        }
    }
}
