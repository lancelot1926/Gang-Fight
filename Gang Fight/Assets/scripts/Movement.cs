using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigBody;
    public float moveSpeed;
    public Vector3 moveDir;
    public float moveX;
    public float moveY;
    public float moveZ;
    private Vector3 lastFingerPos;
    private Vector3 fingerPos;
    private Vector3 newPosForTrans;
    private GameHandler gameHandler;
    [SerializeField] private List<GameObject> colorBomb;
    private Transform partyHolder;
    [SerializeField]private GameObject spawnEffect;
    public bool onGroundCheck;
    [SerializeField] private List<Material> colors;
    private GameObject humanoidChild;
    private Vector3 mousePosition;
    private float horizontal;

    private const float DoubleClickTime = 0.2f;
    private float lastClickTime;

    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        humanoidChild=transform.GetChild(1).gameObject;
        humanoidChild.GetComponent<SkinnedMeshRenderer>().material = colors[UnityEngine.Random.Range(0,colors.Count)];
        if (gameObject.tag == "Avatar")
        {
            gameHandler.avatarList.Add(gameObject);
            gameHandler.PCloneCounter++;
        }

        partyHolder = GameObject.Find("PartyHolder").transform;
        Instantiate(spawnEffect, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
        //Vector3 goRight = new Vector3(3f, transform.position.y, transform.position.z);
        //Vector3 goLeft = new Vector3(-3f, transform.position.y, transform.position.z);
        moveX = 0f;
        moveY = 0f;
        moveZ = 1f;


        /*if(Input.touchCount> 0)
        {
            Touch finger =Input.GetTouch(0);
            fingerPos =Camera.main.ScreenToWorldPoint(finger.position);
            fingerPos.z = 0;

            float xDiff = fingerPos.x - lastFingerPos.x;

            newPosForTrans.x = transform.position.x + xDiff * Time.deltaTime * 5;
            newPosForTrans.y = transform.position.y;
            newPosForTrans.z= transform.position.z;
            
            transform.position = fingerPos*5*Time.deltaTime;
            //lastFingerPos= fingerPos;

            if (finger.deltaPosition.x > 1.0f)
            {
                //transform.position = Vector3.Lerp(transform.position,goRight , 5 * Time.deltaTime);
                //moveX = +1f;
            }
            if (finger.deltaPosition.x < -1.0f)
            {
                //transform.position = Vector3.Lerp(transform.position, goLeft, 5 * Time.deltaTime);
                //moveX = -1f;
            }
        }*/

        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;

            float timeSinceLastClick = Time.time - lastClickTime;
            if(timeSinceLastClick <= DoubleClickTime) {
                if (gameObject.tag == "Avatar")
                {
                    if (gameHandler.partyOnGround)
                    {
                        rigBody.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
                    }

                }
            }

            lastClickTime=Time.time;
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

        //transform.position = new Vector3(Mathf.Clamp(transform.position.x + (370 * horizontal * Time.deltaTime), -3f, 3f), transform.position.y,transform.position.z);
       



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
            /*for(int x = 0; x < gameHandler.avatarList.Count; x++)
            {
                if (gameHandler.avatarList[gameHandler.avatarList.Count-x-1].GetComponent<Movement>().onGroundCheck == true)
                {
                    //if(Time.deltaTime)
                    gameHandler.avatarList[gameHandler.avatarList.Count - x-1].GetComponent<Rigidbody>().AddForce(new Vector3(0, 3, 0), ForceMode.Impulse);
                }
            }*/
            if (gameObject.tag == "Avatar")
            {
                if(gameHandler.partyOnGround)
                {
                    rigBody.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
                }
                
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
        if (gameObject.tag == "Avatar")
        {
            
        }
        //rigBody.velocity = new Vector3(moveDir.x, rigBody.velocity.y, moveDir.z);
        if (gameObject.tag == "PartyHolder")
        {
            //transform.position = gameHandler.avatarList[0].GetComponent<Rigidbody>().position*Time.time;
        }


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
                    if (gameHandler.avatarList[0] == gameObject)
                    {
                        for(int y=0; y < gameHandler.PCloneLimit; y++)
                        {
                            Instantiate(colorBomb[randNum], partyHolder);
                        }
                    }
                    //
                    if (gameObject != gameHandler.avatarList[0])
                    {
                        gameHandler.avatarList.Remove(gameObject);
                        gameHandler.PCloneLimit--;
                        Destroy(gameObject);
                    }
                    if (gameObject == gameHandler.avatarList[0] && gameHandler.avatarList.Count > 1)
                    {

                        gameHandler.MainPAvatar = gameHandler.avatarList[1];
                        //gameHandler.avatarList[1].transform.parent = null;
                        gameHandler.MainPAvatar = gameHandler.avatarList[0];
                        /*for (int x = 2; x < gameHandler.avatarList.Count; x++)
                        {
                            gameHandler.avatarList[x].transform.parent = gameHandler.avatarList[1].transform;
                        }*/
                        gameHandler.avatarList.Remove(gameObject);
                        gameHandler.PCloneLimit--;

                        Destroy(gameObject);
                    }
                    if (gameObject == gameHandler.avatarList[0] && gameHandler.avatarList.Count == 1)
                    {
                        gameHandler.avatarList.Remove(gameObject);
                        gameHandler.PCloneLimit--;
                        Destroy(gameObject);
                    }
                    break;
                case "Obstcale":
                    Debug.Log("!!!!!!!!!!!!");
                    if (gameObject != gameHandler.avatarList[0])
                    {
                        gameHandler.avatarList.Remove(gameObject);
                        gameHandler.PCloneLimit--;
                        Destroy(gameObject);
                    }
                    if (gameObject == gameHandler.avatarList[0] && gameHandler.avatarList.Count > 1)
                    {

                        gameHandler.MainPAvatar = gameHandler.avatarList[1];
                        //gameHandler.avatarList[1].transform.parent = null;
                        gameHandler.MainPAvatar = gameHandler.avatarList[0];
                        /*for (int x = 2; x < gameHandler.avatarList.Count; x++)
                        {
                            gameHandler.avatarList[x].transform.parent = gameHandler.avatarList[1].transform;
                        }*/
                        gameHandler.avatarList.Remove(gameObject);
                        gameHandler.PCloneLimit--;
                        
                        Destroy(gameObject);
                    }
                    if (gameObject == gameHandler.avatarList[0] && gameHandler.avatarList.Count == 1)
                    {
                        gameHandler.avatarList.Remove(gameObject);
                        gameHandler.PCloneLimit--;
                        Destroy(gameObject);
                    }

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
        if (gameObject.tag == "Avatar")
        {
            gameHandler.PCloneCounter--;
            gameHandler.avatarList.Remove(gameObject);

        }
        
    }
}
