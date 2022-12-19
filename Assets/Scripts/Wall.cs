using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Polygon
{
    [SerializeField]
    List<PropMaterial> differentStyleMaterials = new List<PropMaterial>();
    public override void UpdateStyle(Style newstyle)
    {
        base.UpdateStyle(newstyle);
    }
}
