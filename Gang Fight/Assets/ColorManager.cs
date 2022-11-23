using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public int droppedClones;
    public Material material;
    public float r;
    public float g;
    public float b;
    public float a;
    public float maxr;
    public float maxg;
    public float maxb;
    public float maxa;
    // Start is called before the first frame update
    void Start()
    {
        droppedClones = 0;
        material = gameObject.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.O))
        {
            //material.color = new Color(1, 1, 1,1);
            



        }
        if (r <= maxr && g <= maxg && b <= maxb && a <= maxa)
        {
            r += 0.5f * Time.time;
            g += 0.5f * Time.time;
            b += 0.5f * Time.time;
            a += 0.5f * Time.time;
        }

        material.color = new Color(r / 255f, g / 255f, b / 255f, a / 255f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Avatar")
        {
            droppedClones++;
            maxr += 5;
            maxg += 5;
            maxb += 5;
            maxa += 5;
        }
    }
}
