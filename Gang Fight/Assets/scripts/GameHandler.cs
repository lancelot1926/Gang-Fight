using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.Assertions.Must;

public class GameHandler : MonoBehaviour
{
    public GameObject MainPAvatar;
    public GameObject clone;
    //public GameObject partyHolder;
    public List<GameObject> avatarList;
    public bool permission1;
    public int PCloneCounter;
    public int PCloneLimit;
    public bool partyOnGround;
    public ColorManager currentPalette;

    private Vector3 lastEndPosition;
    private GameObject EndLine;
    [SerializeField] private Transform levelPartStart;
    [SerializeField] private List<Transform> levelPartList;
    public Transform EndLevelPart1;


    public PaletteData pdata;
    public string paletteDataFileName;
    public List<PaletteData> paletteDataList=new List<PaletteData>();
    private float timer=0.5f;
    private float timeToJump=0;
    private Transform partyHolder;
    public  bool isGameOver=false;
    public static int runCount;

    private enum PicStates
    {
        None,Ongoing
    }
    private PicStates state;

    
    private void Awake()
    {
        paletteDataList= SaveSystem.ReadListFromJSON<PaletteData>("listdata.json");
        

        if (paletteDataList.Count >= 1)
        {
            if (paletteDataList.Last().isItFull == false)
            {
                pdata = paletteDataList.Last();
            }
            if(paletteDataList.Last().isItFull == true)
            {
                pdata = null;
            }

             // come back and change this later with some better mindset good luck 
            // future me you need to fix this it prevents stacking pdata in that damn list

            /*if (pdata.rgbaValues[0] < 255f)
            {
                pdata.isItFull = false;
                Debug.Log("notFullBaby");
            }
            if (pdata.rgbaValues[0] >= 255f)
            {
                Debug.Log("it was full baby");

                pdata.isItFull= true;

                
            }*/
            
           
        }
        if (paletteDataList.Count == 0)
        {
            Debug.Log(paletteDataList.Count);
            pdata = SaveSystem.ReadFromJSON<PaletteData>(paletteDataFileName);
        }
        /*if (paletteDataList.Contains(pdata))
        {
            Debug.Log(222);
        }*/
        lastEndPosition = levelPartStart.Find("EndPosition").position;
        partyHolder = GameObject.Find("PartyHolder").transform;
        //SpawnLevel();
        
        int passedNum= UnityEngine.Random.Range(1, 9);
        Debug.Log(passedNum);
        
        LevelBuilder(passedNum);
    }
    void Start()
    {

        runCount++;
        Debug.Log(runCount);

       



    }

    // Update is called once per frame
    void Update()
    {
        if (PCloneCounter < PCloneLimit)
        {

            if (partyOnGround == true && avatarList[0]!=null)
            {
                SpawnPClone();
            }
            


        }
        if (PCloneCounter > PCloneLimit)
        {
            RemovePClone();




        }
        if(PCloneCounter==0)
        {
            isGameOver= true;
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            int ranNum = UnityEngine.Random.Range(0, 55);
            currentPalette.meshRenderer.material = currentPalette.picList[ranNum];
            currentPalette.matName = currentPalette.meshRenderer.material.name;
            currentPalette.picName= currentPalette.matName.Substring(0, currentPalette.matName.IndexOf("Mat"));
            currentPalette.r = 0;
            currentPalette.g = 0;
            currentPalette.b = 0;
            currentPalette.a = 0;
            currentPalette.maxr = 0;
            currentPalette.maxg = 0;
            currentPalette.maxb = 0;
            currentPalette.maxa = 0;
            
            Debug.Log(currentPalette.meshRenderer.material.name);
        }

        foreach (GameObject gameObject in avatarList)
        {
            if (gameObject.GetComponent<Movement>().onGroundCheck)
            {
                partyOnGround = true;

            }
        }

        /*if (Input.GetKeyDown(KeyCode.Space))
        {

            /*int x = 0;
            myForLoop(x, avatarList.Count, () => {
                StartCoroutine(jumpDelay(1f, () => {
                    
                    x++;

                }));
                x = 0;
            });


            for (int b = 0; b < avatarList.Count;b++)
            {
                JumpFunc(b);


            }
            if (gameObject.tag == "Avatar")
            {
                //rigBody.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
            }
        }*/

        //Debug.Log(partyOnGround);
        //debug.log(partyOnGround);
    }





    private void SpawnPClone()
    {
        //MainPAvatar.GetComponent<Rigidbody>().isKinematic = true;
        float x = UnityEngine.Random.Range(-0.5f, 0.5f);
        float z = UnityEngine.Random.Range(-0.5f, 0.5f);
        Vector3 newCom=new Vector3(2*x,0,2*z);
        Debug.Log("x= "+x+" "+ "z= " + z);

        GameObject spawnedClone = Instantiate(clone, avatarList[0].transform.parent);
        spawnedClone.transform.position += newCom;
        //PCloneCounter++;
        
        //MainPAvatar.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void RemovePClone()
    {
        if (isGameOver == false)
        {
            GameObject avatar = avatarList.Last();
            //PCloneCounter--;
            avatarList.Remove(avatar);
            Destroy(avatar);
        }
        




    }

    
    private void SpawnLevel()
    {
        Transform lastLevelPosition = SpawnLevelPart(lastEndPosition);
        lastEndPosition = lastLevelPosition.Find("EndPosition").position;
        EndLine = lastLevelPosition.Find("EndLine").gameObject;
    }
    private void SpawnFinish()
    {
        Transform spawnedEnd =Instantiate(EndLevelPart1,lastEndPosition + new Vector3(0, -10, 13), Quaternion.identity);
        spawnedEnd.eulerAngles = new Vector3(0, 180, 0);
        partyHolder.transform.position = spawnedEnd.position;
        EndLine.SetActive(true);
        
        
    }
    private Transform SpawnLevelPart(Vector3 spawnPosition)
    {
        int x = UnityEngine.Random.Range(0, 5);
        Transform levelPartTransform=Instantiate(levelPartList[x], spawnPosition+new Vector3(0,-0.01f,0), Quaternion.identity);
        return levelPartTransform;
    }
    private void LevelBuilder(int playNum)
    {
        if (playNum <= 3)
        {
            int x = UnityEngine.Random.Range(1, 4);
            for (int i = 0; i < x; i++)
            {
                SpawnLevel();
            }
        }
        if (playNum > 3 && playNum <= 7)
        {
            int x = UnityEngine.Random.Range(2, 5);
            for (int i = 0; i < x; i++)
            {
                SpawnLevel();
            }
        }
        if (playNum > 7)
        {
            int x = UnityEngine.Random.Range(3, 6);
            for (int i = 0; i < x; i++)
            {
                SpawnLevel();

            }
        }
        SpawnFinish();
    }

   

    public void SaveTheGame()
    {
        //pdata = new PaletteData(currentPalette);


        PaletteData palette = new PaletteData(currentPalette);
        //paletteDataList.Add(palette);        

        if (paletteDataList.Contains(pdata) == false)
        {
            Debug.Log("bbbbbbbb");
            pdata = new PaletteData(currentPalette);
            paletteDataList.Add(pdata);
        }
        if (paletteDataList.Contains(pdata))
        {
            Debug.Log("çaçaaçaçaça");

            int index = paletteDataList.IndexOf(pdata);
            paletteDataList[index].picName = currentPalette.picName;
            paletteDataList[index].rgbaValues[0] = currentPalette.maxr;
            paletteDataList[index].rgbaValues[1] = currentPalette.maxg;
            paletteDataList[index].rgbaValues[2] = currentPalette.maxb;
            paletteDataList[index].rgbaValues[3] = currentPalette.maxa;

            Debug.Log(pdata.rgbaValues[0]);
        }
        else
        {

        }
        if (pdata.rgbaValues[0] < 255f)
        {
            pdata.isItFull = false;
            Debug.Log("notFullBaby");
        }
        if (pdata.rgbaValues[0] >= 255f)
        {
            Debug.Log("it was full baby");

            pdata.isItFull = true;


        }
        SaveSystem.SaveToJSON<PaletteData>(paletteDataList, "listdata.json");


    }
}
