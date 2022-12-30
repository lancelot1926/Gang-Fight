using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public string picName;
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
    public GameHandler gmHandler;
    public MeshRenderer meshRenderer;
    public List<Material> picList;
    public string matName;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        meshRenderer= GetComponent<MeshRenderer>();
        gmHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        gmHandler.currentPalette = this;
        droppedClones = 0;
        material = gameObject.GetComponent<MeshRenderer>().material;
        
        meshRenderer.material = picList[2];
        matName = meshRenderer.material.name;
        picName=matName.Substring(0,matName.IndexOf("Mat"));
        Debug.Log(picName);
        /*if (matName.Contains("Marin"))
        {
            Debug.Log("Marinnnnnnn");
            picName = "Marin";
        }
        if (matName.Contains("Renna"))
        {
            Debug.Log("Rennaaaaaa");
            picName = "Renna";
        }*/
        if (gmHandler.pdata != null)
        {
            //Debug.Log(gmHandler.pdata.rgbaValues[0]);
            maxr = gmHandler.pdata.rgbaValues[0];
            maxg = gmHandler.pdata.rgbaValues[1];
            maxb = gmHandler.pdata.rgbaValues[2];
            maxa = gmHandler.pdata.rgbaValues[3];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)) {
            droppedClones++;
            maxr += 5;
            maxg += 5;
            maxb += 5;
            maxa += 5;
        }
        
        if (r <= maxr && g <= maxg && b <= maxb && a <= maxa)
        {
            r += 0.5f * Time.time;
            g += 0.5f * Time.time;
            b += 0.5f * Time.time;
            a += 0.5f * Time.time;
        }

        meshRenderer.material.color = new Color(r / 255f, g / 255f, b / 255f, a / 255f);
    }

    public void SetEndPic(PaletteData pData)
    {

    }

    private void SetName()
    {
        
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
