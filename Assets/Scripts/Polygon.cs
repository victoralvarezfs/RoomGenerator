using UnityEngine;
using System;

public interface PolygonMethods
{
    public abstract void UpdateStyle(Style s);
}

public class Polygon : MonoBehaviour, PolygonMethods
{
    [SerializeField]
    BasePolygon properties;
    BaseResources resources;

    void OnEnable()
    {
        properties._Renderer = GetComponentInChildren<Renderer>();
        resources = BaseResources.Instance;
    }

    public BasePolygon Properties
    {
        get => properties;
        set => properties = value;
    }

    public BaseResources _resources => resources;

    public virtual void UpdateStyle(Style newstyle)
    {

    }
}
public enum PolygonType
{
    wall,
    floor,
    prop,
    portal
}
[Serializable]
public class BasePolygon
{
    [SerializeField]
    string id;
    [SerializeField]
    string polyName;
    [SerializeField]
    Material _material;
    [SerializeField]
    Texture _texture;
    [SerializeField]
    Color _color;
    [SerializeField, Range(1,3)]
    int baseSize = 1;
    [SerializeField]
    PolygonType type;
    [SerializeField]
    Style style;
    Renderer renderer;

    public string _Id
    {
        get => id;
        set => id = value;
    }

    public string PolyName  
    {
        get => polyName;
        set => polyName = value;
    }

    public Material _Material
    {
        get => _material;
        set => _material = value;
    }

    public Texture _Texture
    {
        get => _texture;
        set => _texture = value;
    }

    public Color _Color
    {
        get => _color;
        set => _color = value;
    }

    public int BaseSize
    {
        get => baseSize;
        set => baseSize = value;
    }

    public PolygonType PolygonType
    {
        get => type;
        set => type = value;
    }

    public Style _Style
    {
        get => style;
        set => style = value;
    }
    public Renderer _Renderer
    {
        get => renderer;
        set => renderer = value;
    }
}
