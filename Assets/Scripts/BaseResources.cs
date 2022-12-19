using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseResources : MonoBehaviour
{
    [SerializeField]
    List<PropMaterial> differentStyle_FLOOR_Materials = new List<PropMaterial>();
    
    [SerializeField]
    List<PropMaterial> differentStyle_Wall_Materials = new List<PropMaterial>();

    public static BaseResources Instance;

    void Awake() => Instance = this;

    public Material GetMaterial(Style s)
    {
        Material seekedMaterial = null;
        foreach(var mat in differentStyle_FLOOR_Materials)
        {
            if (mat.style.Equals(s))
                seekedMaterial = mat._material;
        }
        return seekedMaterial;
    }
}
