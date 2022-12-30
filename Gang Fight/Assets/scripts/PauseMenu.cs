using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseButton;
    public static bool GameIsPaused=false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            
        }
    }

    /*public void PauseControl()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }*/

    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused= true;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
