using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpee = 0.125f;
    public Vector3 offset;
    public Camera cam;
    private void LateUpdate()
    {
        transform.position = target.position+offset;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            //transform.Rotate(new Vector3(180, 0, 0));
            transform.eulerAngles = new Vector3(90, 0, 0);
            offset = new Vector3(0, 30, 5);
        }
    }
}
