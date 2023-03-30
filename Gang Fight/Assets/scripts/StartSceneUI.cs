using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartSceneUI : MonoBehaviour
{
    [SerializeField]
    private GameObject MenuGroup;

    [SerializeField]
    private GameObject GalleryGroup;

    [SerializeField]
    private GameObject HowToPlayGroup;

    [SerializeField]
    private GameObject LogoGroup;

    private GameObject currentGroup;

    public GameObject musicObject;
    public GameObject musicHolder;

    // Start is called before the first frame update
    void Start()
    {
        musicHolder = GameObject.Find("MusicHolder");
        musicObject = musicHolder.transform.GetChild(0).gameObject;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }





    public void OpenMenuGroup()
    {
        currentGroup.SetActive(false);
        currentGroup= null;
        MenuGroup.SetActive(true);
        LogoGroup.SetActive(true);

    }

    public void OpenGalleryGroup()
    {
        MenuGroup.SetActive(false);
        LogoGroup.SetActive(false);
        GalleryGroup.SetActive(true);
        currentGroup = GalleryGroup;
    }
    public void OpenHowToPlayGroup()
    {
        
        LogoGroup.SetActive(false);
        MenuGroup.SetActive(false);
        HowToPlayGroup.SetActive(true);
        currentGroup = HowToPlayGroup;
    }

    public void StartButton()
    {
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

    public void QuitGame()
    {
        Application.Quit();
    }
}
