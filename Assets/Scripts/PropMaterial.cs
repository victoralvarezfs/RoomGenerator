using System;
using UnityEngine;

[Serializable]
public class PropMaterial
{
    [SerializeField]
    Material material;
    [SerializeField]
    Style materialStyle;
    
    public Material _material
    {
        get => material;
    }

    public Style style => materialStyle;

}
