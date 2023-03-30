using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PaletteData
{
    public string picName;
    public float[] rgbaValues;
    public bool isItFull;

    public PaletteData(ColorManager cManager)
    {
        picName = cManager.picName;
        rgbaValues = new float[4];
        rgbaValues[0] = cManager.maxr;
        rgbaValues[1] = cManager.maxg;
        rgbaValues[2] = cManager.maxb;
        rgbaValues[3] = cManager.maxa;
        

    }

}
