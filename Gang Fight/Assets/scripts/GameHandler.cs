using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameHandler : MonoBehaviour
{
    public GameObject MainPAvatar;
    public GameObject clone;
    public GameObject partyHolder;
    public List<GameObject> avatarList;
    public bool permission1;
    public int PCloneCounter;
    public int PCloneLimit;

    private Vector3 lastEndPosition;
    [SerializeField] private Transform levelPartStart;
    [SerializeField] private List<Transform> levelPartList;
    public Transform EndLevelPart1;
    

    void Start()
    {
        
        lastEndPosition = levelPartStart.Find("EndPosition").position;
        //SpawnLevel();
        LevelBuilder(5);



    }

    // Update is called once per frame
    void Update()
    {
        if (PCloneCounter < PCloneLimit)
        {

            SpawnPClone();


        }
        if (PCloneCounter > PCloneLimit)
        {
            RemovePClone();




        }

        
    }





    private void SpawnPClone()
    {
        //MainPAvatar.GetComponent<Rigidbody>().isKinematic = true;
        float x = Random.Range(-0.5f, 0.5f);
        float z = Random.Range(-0.5f, 0.5f);
        Vector3 newCom=new Vector3(x,0,z);
        GameObject spawnedClone = Instantiate(clone, partyHolder.transform);
        spawnedClone.transform.position += newCom;
        //PCloneCounter++;
        
        //MainPAvatar.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void RemovePClone()
    {
        GameObject avatar = avatarList.Last();
        //PCloneCounter--;
        avatarList.Remove(avatar);
        Destroy(avatar);




    }

    private void LevelBuilder(int playNum)
    {
        if (playNum <= 10)
        {
            int x = Random.Range(1, 4);
            for(int i = 0; i < x; i++)
            {
                SpawnLevel();
            }
        }
        if (playNum > 10&&playNum<=20)
        {
            int x = Random.Range(2, 5);
            for (int i = 0; i < x; i++)
            {
                SpawnLevel();
            }
        }
        if (playNum > 20)
        {
            int x = Random.Range(3, 6);
            for (int i = 0; i < x; i++)
            {
                SpawnLevel();
               
            }
        }
        SpawnFinish();
    }
    private void SpawnLevel()
    {
        Transform lastLevelPosition = SpawnLevelPart(lastEndPosition);
        lastEndPosition = lastLevelPosition.Find("EndPosition").position;
    }
    private void SpawnFinish()
    {
        Transform spawnedEnd =Instantiate(EndLevelPart1,lastEndPosition + new Vector3(0, -10, 10), Quaternion.identity);
        spawnedEnd.eulerAngles = new Vector3(0, 180, 0);
        
    }
    private Transform SpawnLevelPart(Vector3 spawnPosition)
    {
        int x = Random.Range(0, 5);
        Transform levelPartTransform=Instantiate(levelPartList[x], spawnPosition+new Vector3(0,-0.01f,0), Quaternion.identity);
        return levelPartTransform;
    }
}
