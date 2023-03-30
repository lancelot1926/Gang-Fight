using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject endMenu;
    public static bool GameIsPaused=false;
    private GameHandler gameHandler;
    public GameObject musicObject;
    public GameObject musicHolder;
    [SerializeField] private InterstitialAdsButton interAdButton;

    private void Start()
    {
        gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        musicHolder = GameObject.Find("MusicHolder");
        musicObject = musicHolder.transform.GetChild(0).gameObject;
    }

    void Update()
    {

        if (gameHandler.isGameOver==true)
        {
            endMenu.SetActive(true);
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

    public void Quit()
    {
        gameHandler.SaveTheGame();
        Time.timeScale = 1f;
        GameIsPaused = false;
        //gameHandler.SaveTheGame();
        SceneManager.LoadScene(0);
    }

    public void RunAgain()
    {
        gameHandler.SaveTheGame();
        if (GameHandler.runCount % 5 == 0)
        {
            Debug.Log("Reklamlarrrrr");
            interAdButton.ShowAd();
            
        }
        SceneManager.LoadScene(1);
        
    }
    public void MuteMusic()
    {
        if (musicObject.activeSelf == true)
        {
            musicObject.SetActive(false);
        }
        else
        {
            musicObject.SetActive(true);
        }

    }

}
