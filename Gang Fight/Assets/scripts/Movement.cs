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

    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        if (gameObject.tag == "Avatar")
        {
            gameHandler.avatarList.Add(gameObject);
            gameHandler.PCloneCounter++;
        }
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
            
            if (gameObject.tag == "Avatar")
            {
                rigBody.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
            }
        }

        moveDir = new Vector3(moveX, moveY,moveZ).normalized*moveSpeed;
    }



    private void FixedUpdate()
    {
        rigBody.velocity = new Vector3(moveDir.x,rigBody.velocity.y,moveDir.z);

        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Avatar")
        {
            if (collision.transform.tag == "Obstcale")
            {
                gameHandler.avatarList.Remove(gameObject);
                gameHandler.PCloneLimit--;
                Destroy(gameObject);
            }
            else
            {

            }

           
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        /*if (gameObject.tag == "Avatar")
        {
            if (collision.transform.tag == "Obstcale")
            {
                //gameHandler.avatarList.Remove(gameObject);
                gameHandler.PCloneLimit--;
                //Destroy(gameObject);
            }
            else
            {

            }
        }*/
    }

    private void OnDestroy()
    {
        gameHandler.PCloneCounter--;
    }
}
