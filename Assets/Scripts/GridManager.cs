using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class manages the requesting of GridObjects to move to a new space.

public class GridManager : MonoBehaviour
{
    #region Singleton
    public static GridManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    #endregion

    [SerializeField]
    static Vector2 gridSize = new Vector2(1, 1);

    public List<GridObject> gridObjects = new List<GridObject>();

    private void Start()
    {
        foreach (GridObject obj in Resources.FindObjectsOfTypeAll(typeof(GridObject)))
        {
            gridObjects.Add(obj);
        }
    }

    // Converts an arbitrary X and Z position to a grid position
    public static Vector2Int WorldToGrid(Vector2 worldPosition)
    {
        return Vector2Int.RoundToInt(worldPosition / gridSize);
    }

    // Converts a grid position to a world position
    public static Vector2 GridToWorld(Vector2Int gridPosition)
    {
        return gridPosition * gridSize;
    }

    public bool RequestMove(GridObject obj, Vector2Int pos)
    {
        if (gridObjects.Count == 0)
        {
            obj.Move(pos);
            return true;
        }

        Vector2Int relativePos = pos - obj.gridPosition;

        for (int i = 0; i < gridObjects.Count; i++)
        {
            if (gridObjects[i].gridPosition == pos)
            {
                if (gridObjects[i].GetType() == typeof(Wall))
                {
                    return false;
                }
                else
                {
                    return RequestMove(gridObjects[i], pos + relativePos);
                }
            }
            else
            {
                obj.Move(pos);
                return true;
            }
        }
        return false;
    }
}
