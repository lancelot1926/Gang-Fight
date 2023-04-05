using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLine : MonoBehaviour
{
    private Camera cam;
    private CameraFollow camFollow;
    private GameHandler gameHandler;
    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        cam = Camera.main;
        camFollow=cam.GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == gameHandler.avatarList[0]&&gameHandler.avatarList.Count>0)
        {
            camFollow.ChangeCam();

        }
    }
}
