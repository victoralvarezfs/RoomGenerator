using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEditor;

public enum RoomType
{
    Lounge = 1,
    LivingRoom = 2,
    Garden = 3,
    Restroom = 4
}

public enum RoomShape
{
    ClassicSquare = 1,
    Polygonal = 2
}

public enum Style
{
    modern = 0,
    modern1 = 1,
    classic = 2,
    minimalistic = 3
}

[CreateAssetMenu(menuName = "FSStudio/VRRoom")]
public class VRRoom : ScriptableObject
{
    [SerializeField]
    GameObject floorPrefab;
    [SerializeField]
    GameObject wallPrefab;
    [SerializeField]
    RoomType roomType;
    [SerializeField]
    RoomShape roomShape;
    [SerializeField]
    Style roomStyle;
    [SerializeField, ReadOnly]
    List<Polygon> roomPolygons = new List<Polygon>();
    [SerializeField]
    Vector2 size;
    [SerializeField]
    GameObject emptyFather;
    [SerializeField, ReadOnly]
    GameObject vrRoom;

    bool roomCreated;

    void InstantiatePolygon(Vector3 newPos, Vector3 newRot, GameObject newPoly, string name)
    {
        GameObject newPolygon = GameObject.Instantiate(newPoly);
        roomPolygons.Add(newPolygon.GetComponent<Polygon>());
        newPolygon.transform.localPosition = newPos;
        newPolygon.transform.localEulerAngles = newRot;
        newPolygon.name += name;
        newPolygon.transform.SetParent(vrRoom.transform);
    }

    [Button, ShowIf("roomShape", RoomShape.Polygonal)]
    public void CreateRoom()
    {
        Vector3 newPos = Vector3.zero;
        vrRoom = GameObject.Instantiate(emptyFather);
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {

                //to do:  create a pool for floor and props, another pool for walls and doors and windows


                //Create floor
                InstantiatePolygon(newPos, Vector3.zero, floorPrefab, "_" + i.ToString() + "_" + j.ToString());

                //First row walls
                if (i == 0 && j == 0)
                {
                    InstantiatePolygon(newPos, new Vector3(0, 0, 0), wallPrefab, "_" + i.ToString() + "_" + j.ToString());
                    InstantiatePolygon(newPos, new Vector3(0, 270, 0), wallPrefab, "_" + i.ToString() + "_" + j.ToString());

                }
                else if (i == 0 && (j == size.y - 1))
                {
                    InstantiatePolygon(newPos, new Vector3(0, 0, 0), wallPrefab, "_" + i.ToString() + "_" + j.ToString());
                    InstantiatePolygon(newPos, new Vector3(0, 90, 0), wallPrefab, "_" + i.ToString() + "_" + j.ToString());
                }
                else if (i == (size.x - 1) && j == 0)
                {
                    InstantiatePolygon(newPos, new Vector3(0, 270, 0), wallPrefab, "_" + i.ToString() + "_" + j.ToString());
                    InstantiatePolygon(newPos, new Vector3(0, 180, 0), wallPrefab, "_" + i.ToString() + "_" + j.ToString());
                }
                else if (i == (size.x - 1) && j == (size.y - 1))
                {
                    InstantiatePolygon(newPos, new Vector3(0, 180, 0), wallPrefab, "_" + i.ToString() + "_" + j.ToString());
                    InstantiatePolygon(newPos, new Vector3(0, 90, 0), wallPrefab, "_" + i.ToString() + "_" + j.ToString());
                }
                else
                {
                    if (i == 0)
                    {
                        InstantiatePolygon(newPos, new Vector3(0, 0, 0), wallPrefab, "_" + i.ToString() + "_" + j.ToString());
                    }
                    else if (j == 0)
                    {
                        InstantiatePolygon(newPos, new Vector3(0, 270, 0), wallPrefab, "_" + i.ToString() + "_" + j.ToString());
                    }
                    else if (j == (size.y - 1))
                    {
                        InstantiatePolygon(newPos, new Vector3(0, 90, 0), wallPrefab, "_" + i.ToString() + "_" + j.ToString());
                    }
                    else if (i == (size.x - 1))
                    {
                        InstantiatePolygon(newPos, new Vector3(0, 180, 0), wallPrefab, "_" + i.ToString() + "_" + j.ToString());
                    }
                }

                //Update position for next polygon
                newPos = new Vector3((newPos.x + 1), newPos.y, newPos.z);

                //Reached the right edge of the floor
                if (((j % (size.y - 1)) == 0) && j > 0)
                {
                    //Sets position for the new row
                    newPos = new Vector3(0, newPos.y, newPos.z - 1);
                }
            }
        }
        roomCreated = true;
    }

    [Button, ShowIf("roomShape", RoomShape.Polygonal)]
    public void DeleteRoom()
    {
        DestroyImmediate(vrRoom);
        roomPolygons.Clear();
        roomCreated = false;
    }

    [Button, ShowIf("roomCreated", true)]
    public void CreatePrefab()
    {
        Selection.activeObject = vrRoom;
        GameObject[] gameobjects = Selection.gameObjects;
        foreach (var g in gameobjects)
        {
            string localPath = "Assets/Prefabs/NewVRRoom" + ".prefab";
            localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
            bool prefabSuccess;
            PrefabUtility.SaveAsPrefabAssetAndConnect(g, localPath, InteractionMode.UserAction, out prefabSuccess);

            if (prefabSuccess == true)
                Debug.Log("Prefab was saved successfully");
            else
                Debug.Log("Prefab failed to save" + prefabSuccess);
        }
    }

    public void UpdateStyle()
    {
        foreach (var prop in roomPolygons)
            prop.UpdateStyle(roomStyle);
            
    }

}
