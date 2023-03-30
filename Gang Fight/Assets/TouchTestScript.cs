using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch=Input.GetTouch(0);

            if(touch.phase== TouchPhase.Began)
            {
                Debug.Log("Touched");
            }
            if (touch.phase == TouchPhase.Stationary)
            {
                Debug.Log("Touching");
            }
            if (touch.phase == TouchPhase.Moved)
            {
                Debug.Log("Swiping");
            }
            if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("Touch ended");
            }
        }
    }
}
