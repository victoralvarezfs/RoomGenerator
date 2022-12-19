using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : Polygon
{
    [SerializeField]
    List<Furniture> differentStyleProps = new List<Furniture>();

    public override void UpdateStyle(Style newstyle)
    {
        ChangeFurnitureStyle(newstyle);
    }

    void ChangeFurnitureStyle(Style newstyle)
    {
        if(differentStyleProps.Count > 0)
        {
            foreach(var prop in differentStyleProps)
            {
                if(prop._style == newstyle)
                {
                    Properties._Renderer = prop._mesh;
                }
            }
        }
    }
}
