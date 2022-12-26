using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffScript : MonoBehaviour
{
    public string type;
    public int value;
    private GameHandler gameHandler;
    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == gameHandler.avatarList[0])
        {
            switch (type)
            {
                case "Buff":
                    gameHandler.PCloneLimit += value;
                    break;

                case "Debuff":
                    gameHandler.PCloneLimit -= value;
                    break;
            }
            
        }
    }
}
