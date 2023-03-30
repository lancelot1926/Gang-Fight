using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuffScript : MonoBehaviour
{
    public string type;
    public int value;
    private GameHandler gameHandler;
    [SerializeField] private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        switch (type)
        {
            case "Buff":
                value = UnityEngine.Random.Range(2, 5);
                text.text = "+"+value.ToString();
                break;

            case "Debuff":
                value=UnityEngine.Random.Range(1, 4);
                text.text = "-"+value.ToString();
                break;
                
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == gameHandler.avatarList[0].transform.GetChild(0).GetChild(0).gameObject)
        {
            switch (type)
            {
                case "Buff":
                    gameHandler.PCloneLimit += value;
                    break;

                case "Debuff":
                    gameHandler.PCloneLimit -= value;
                    if (gameHandler.PCloneLimit < 0)
                    {
                        gameHandler.PCloneLimit = 0;
                    }
                    break;
            }
            
        }
    }
}
