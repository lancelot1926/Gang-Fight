using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpee = 0.125f;
    public Vector3 offset;
    public Camera cam;
    
    private GameHandler gameHandler;
    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
    }
    private void LateUpdate()
    {
        if (target == null&& gameHandler.avatarList.Count!=0)
        {
           target= gameHandler.avatarList[0].transform;
        }
        if (target != null)
        {
            transform.position = target.position + offset;
        }
        
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            target = GameObject.Find("Plane(Clone)").transform;
            //transform.Rotate(new Vector3(180, 0, 0));
            transform.eulerAngles = new Vector3(90, 0, 0);
            offset = new Vector3(0, 30, 0);
        }
    }


    public void ChangeCam()
    {
        target = GameObject.Find("Plane(Clone)").transform;
        //transform.Rotate(new Vector3(180, 0, 0));
        transform.eulerAngles = new Vector3(90, 0, 0);
        offset = new Vector3(0, 30, 0);
    }
}
