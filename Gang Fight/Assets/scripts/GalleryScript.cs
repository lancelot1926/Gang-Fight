using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GalleryScript : MonoBehaviour
{

    public List<Sprite> picList;
    public List<Sprite> avaiblePicList;

    public Image picHolder;
    public TextMeshProUGUI picNameText;
    public TextMeshProUGUI picCounter;


    public List<PaletteData> paletteDataList = new List<PaletteData>();
    public PaletteData pdata;

    public int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        paletteDataList = SaveSystem.ReadListFromJSON<PaletteData>("listdata.json");
        if (paletteDataList.Count > 0)
        {

            for (int x = 0; x < picList.Count; x++)
            {
                int carrier = x;
                for (int y = 0; y < paletteDataList.Count; y++)
                {
                    if (paletteDataList[y].picName.Contains(picList[carrier].name) && paletteDataList[y].isItFull == true)
                    {
                        Debug.Log("Check");
                        avaiblePicList.Add(picList[carrier]);
                    }
                }
            }

            picHolder.sprite = avaiblePicList[counter];
            picHolder.color= Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (paletteDataList.Count > 0)
        {
            picHolder.sprite = avaiblePicList[counter];
            picNameText.text = avaiblePicList[counter].name;
            picCounter.text = counter+1 + "/" + avaiblePicList.Count;
            if (Input.GetKeyDown(KeyCode.H))
            {
                if (counter < avaiblePicList.Count)
                {
                    counter++;
                }
                if (counter == avaiblePicList.Count)
                {
                    counter = 0;
                }

            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                if (counter > -1)
                {
                    counter--;
                }
                if (counter == -1)
                {
                    counter = avaiblePicList.Count - 1;
                }

            }
        }
        
    }



    public void IncreaseCounter()
    {
        if (paletteDataList.Count > 0)
        {

            if (counter < avaiblePicList.Count)
            {
                counter++;
            }
            if (counter == avaiblePicList.Count)
            {
                counter = 0;
            }

        }
    }

    public void DecreaseCounter()
    {
        if (paletteDataList.Count > 0)
        {

            if (counter > -1)
            {
                counter--;
            }
            if (counter == -1)
            {
                counter = avaiblePicList.Count - 1;
            }

        }
    }



}





