using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : Polygon
{    

    public override void UpdateStyle(Style newstyle)
    {
        UpdateMaterial(newstyle);
    }

    void UpdateMaterial(Style s)
    {
        Properties._Material = _resources.GetMaterial(s);
    }
}
