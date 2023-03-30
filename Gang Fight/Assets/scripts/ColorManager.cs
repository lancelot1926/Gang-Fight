using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Assertions.Must;
using System.Linq;

public class ColorManager : MonoBehaviour
{
    public string picName;
    public bool palletteIsFull=true;
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
        
        
        SetEndPic(gmHandler.pdata);
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
        if (gmHandler.pdata != null&&gmHandler.pdata.isItFull==false)
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
            maxr += 100;
            maxg += 100;
            maxb += 100;
            maxa += 100;
        }
        
        if (r <= maxr && g <= maxg && b <= maxb && a <= maxa)
        {
            r += 0.5f * Time.time;
            g += 0.5f * Time.time;
            b += 0.5f * Time.time;
            a += 0.5f * Time.time;
        }
        if (maxr == 0)
        {
            r=0;
            g=0;
            b=0;
            a=0;

        }

        meshRenderer.material.color = new Color(r / 255f, g / 255f, b / 255f, a / 255f);
    }

    public void SetEndPic(PaletteData pData)
    {
        if(gmHandler.paletteDataList.Count >= 55 && gmHandler.paletteDataList.Last().isItFull)
        {
            int ranNum = UnityEngine.Random.Range(0, 55);
            meshRenderer.material = picList[ranNum];
            matName = meshRenderer.material.name;
            picName = matName.Substring(0, matName.IndexOf("Mat"));
            Debug.Log(picName);
            Debug.Log("Check");
        }
        if (gmHandler.paletteDataList.Count >= 1 && gmHandler.paletteDataList.Last().isItFull)
        {
            Debug.Log("çokokokoko");
            bool newPicSet = false;

            for (int x = 0; x < gmHandler.paletteDataList.Count; x++)
            {
                
                if (newPicSet == false)
                {
                    int ranNum = UnityEngine.Random.Range(0, 55);
                    for (int y = 0; y < gmHandler.paletteDataList.Count; y++)
                    {
                        if (picList[ranNum].name.Contains(gmHandler.paletteDataList[y].picName))
                        {
                            Debug.Log("Break Bitch");
                            break;
                        }
                        if (y == gmHandler.paletteDataList.Count - 1)
                        {
                            meshRenderer.material = picList[ranNum];
                            matName = meshRenderer.material.name;
                            picName = matName.Substring(0, matName.IndexOf("Mat"));
                            newPicSet = true;
                            Debug.Log(picName);
                            Debug.Log("Check");
                            break;


                        }
                    }
                }
                
                
                /*if (picList[ranNum].name.Contains(gmHandler.paletteDataList[x].picName) == false)
                {
                    
                }*/
            }
            
        }
        if (gmHandler.paletteDataList.Count >= 1 && gmHandler.paletteDataList.Last().isItFull==false)
        {
            Debug.Log("yaharrooooo");
            
            meshRenderer.material = picList.Find(x => x.name.Contains(pData.picName));
            matName = meshRenderer.material.name;
            picName = matName.Substring(0, matName.IndexOf("Mat"));
            Debug.Log(pData.picName);
        }

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
