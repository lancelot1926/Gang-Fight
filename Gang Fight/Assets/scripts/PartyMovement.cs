using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMovement : MonoBehaviour
{
    private Vector3 mousePosition;
    private float horizontal;

    private GameHandler gameHandler;
    
    private Vector3 moveDir;

    void Start()
    {
        gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
    }

    
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {

            horizontal = (Input.mousePosition.x - mousePosition.x) / Screen.width * 2.5f;

            mousePosition = Input.mousePosition;
        }
        else
        {
            horizontal = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            /*for(int x = 0; x < gameHandler.avatarList.Count; x++)
            {
                if (gameHandler.avatarList[gameHandler.avatarList.Count-x-1].GetComponent<Movement>().onGroundCheck == true)
                {
                    //if(Time.deltaTime)
                    gameHandler.avatarList[gameHandler.avatarList.Count - x-1].GetComponent<Rigidbody>().AddForce(new Vector3(0, 3, 0), ForceMode.Impulse);
                }
            }*/

            
            if (gameHandler.partyOnGround)
            {
                
            }
        }
        moveDir = new Vector3(0, 0, 0).normalized * 5;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x + (370 * horizontal * Time.deltaTime), -8f, 8f), transform.position.y, transform.position.z + (8 * Time.deltaTime));

        
    }
    
}
