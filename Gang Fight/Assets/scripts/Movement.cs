using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigBody;
    public float moveSpeed;
    public Vector3 moveDir;
    public float moveX;
    public float moveY;
    public float moveZ;
    private GameHandler gameHandler;
    [SerializeField] private List<GameObject> colorBomb;
    private Transform partyHolder;

    private bool onGroundCheck;

    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        if (gameObject.tag == "Avatar")
        {
            gameHandler.avatarList.Add(gameObject);
            gameHandler.PCloneCounter++;
        }
        partyHolder = GameObject.Find("PartyHolder").transform;
    }

    // Update is called once per frame
    void Update()
    {
        moveX = 0f;
        moveY = 0f;
        moveZ = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            moveZ = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveZ = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for(int x = 0; x < gameHandler.avatarList.Count; x++)
            {
                if (gameHandler.avatarList[gameHandler.avatarList.Count-x-1].GetComponent<Movement>().onGroundCheck == true)
                {
                    //if(Time.deltaTime)
                    gameHandler.avatarList[gameHandler.avatarList.Count - x-1].GetComponent<Rigidbody>().AddForce(new Vector3(0, 3, 0), ForceMode.Impulse);
                }
            }
            if (gameObject.tag == "Avatar")
            {
                //rigBody.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
            }
        }

        moveDir = new Vector3(moveX, moveY,moveZ).normalized*moveSpeed;
        if (gameObject.tag == "Avatar")
        {
            //Debug.Log(onGroundCheck);
        }
        
    }



    private void FixedUpdate()
    {
        rigBody.velocity = new Vector3(moveDir.x,rigBody.velocity.y,moveDir.z);

        

    }
    /*private void colCheck(Collision col)
    {
        if (col.transform.tag == "Obstcale")
        {
            gameHandler.avatarList.Remove(gameObject);
            gameHandler.PCloneLimit--;
            Destroy(gameObject);
        }

        if (col.transform.tag == "Palette")
        {
            Debug.Log("!!!!!!!!!!!!");
            Instantiate(colorBomb, partyHolder);
            Destroy(gameObject);
        }
    }*/
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Avatar")
        {
            switch (collision.transform.tag)
            {
                case "Palette":
                    Debug.Log("!!!!!!!!!!!!");
                    int randNum=Random.Range(0, colorBomb.Count);
                    Instantiate(colorBomb[randNum], partyHolder);
                    Destroy(gameObject);
                    break;
                case "Obstcale":
                    Debug.Log("!!!!!!!!!!!!");
                    gameHandler.avatarList.Remove(gameObject);
                    gameHandler.PCloneLimit--;
                    Destroy(gameObject);
                    break;

                

            }
            /*if (collision.transform.tag == "Obstcale")
            {
                
            }
            
            if (collision.transform.tag == "Palette")
            {
                
            }*/

        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (gameObject.tag == "Avatar")
        {
            if (collision.transform.tag == "Ground")
            {
                //gameHandler.avatarList.Remove(gameObject);
                gameHandler.partyOnGround = true;
                onGroundCheck= true;
                
                //Destroy(gameObject);
            }
            else
            {
                gameHandler.partyOnGround = false;
                onGroundCheck= false;
            }

            //Debug.Log(collision.transform.tag);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (gameObject.tag == "Avatar")
        {
            if (collision.transform.tag == "Ground")
            {
                //gameHandler.avatarList.Remove(gameObject);
                gameHandler.partyOnGround = false;
                onGroundCheck = false;
                //Destroy(gameObject);
            }
            
        }
    }

    private void OnDestroy()
    {
        gameHandler.PCloneCounter--;
        gameHandler.avatarList.Remove(gameObject);
    }
}
