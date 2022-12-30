using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyHolder : MonoBehaviour
{

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



    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ground")
        {
            gameHandler.partyOnGround= true;
        }
    }

}
