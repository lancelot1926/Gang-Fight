using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cloneCount;
    [SerializeField] private Slider phillIndicator;

    private ColorManager colorManager;
    private GameHandler gameHandler;
    // Start is called before the first frame update
    void Start()
    {
        //colorManager = GameObject.FindGameObjectWithTag("Palette").GetComponent<ColorManager>();
        colorManager = GameObject.FindWithTag("Palette").GetComponent<ColorManager>();
        gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        
        phillIndicator.minValue= 0f;
        phillIndicator.maxValue = 255f;
    }
    

    // Update is called once per frame
    void Update()
    {
        cloneCount.text = "" + gameHandler.PCloneLimit;
        phillIndicator.value = colorManager.r;
    }
}
