using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLine : MonoBehaviour
{
    private Camera cam;
    private CameraFollow camFollow;
    // Start is called before the first frame update
    void Start()
    {
        cam= Camera.main;
        camFollow=cam.GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PartyHolder")
        {
            camFollow.ChangeCam();

        }
    }
}
