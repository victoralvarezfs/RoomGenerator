using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    [SerializeField]
    Style style;
    [SerializeField]
    Renderer mesh;

    public Style _style
    {
        get => style;
        set => style = value;
    }
    public Renderer _mesh
    {
        get => mesh;
        set => mesh = value;
    }

    void OnEnable()
    {
        mesh = GetComponent<Renderer>();    
    }
}
