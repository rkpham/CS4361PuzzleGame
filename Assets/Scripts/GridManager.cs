using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class manages the requesting of GridObjects to move to a new space.

public class GridManager : MonoBehaviour
{
    // Code to make this a singleton (look up singleton design pattern)
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
    static Vector3 gridSize = new Vector3(1, 1, 1);

    public List<GridObject> gridObjects = new List<GridObject>();

    private void Start()
    {
        foreach (GridObject obj in Resources.FindObjectsOfTypeAll(typeof(GridObject)))
        {
            gridObjects.Add(obj);
        }
    }

    // Converts an world position to a grid position
    public static Vector3Int WorldToGrid(Vector3 worldPosition)
    {
        Vector3 gridScaled = new Vector3(worldPosition.x / gridSize.x, worldPosition.y / gridSize.y, worldPosition.z / gridSize.z);
        return Vector3Int.RoundToInt(gridScaled);
    }

    // Converts a grid position to a world position
    public static Vector3 GridToWorld(Vector3Int gridPosition)
    {
        return new Vector3(gridPosition.x * gridSize.x, gridPosition.y * gridSize.y, gridPosition.z * gridSize.z);
    }

    // Handles requests by GridObjects to move to a certain arbitrary global grid position.
    public bool RequestMove(GridObject obj, Vector3Int pos)
    {
        if (gridObjects.Count == 0)
        {
            obj.Move(pos);
            return true;
        }

        Vector3Int relativePos = pos - obj.gridPosition;
        bool allowMove = true;

        for (int i = 0; i < gridObjects.Count; i++)
        {
            var gridObject = gridObjects[i];
            if (gridObject.gridPosition == pos)
            {
                if (gridObject.GetType() == typeof(Wall))
                {
                    // Block things from moving into walls
                    allowMove = false;
                }
                else if (gridObject.GetType() == typeof(Box))
                {
                    // Recursively push blocks in a row if found
                    allowMove = RequestMove(gridObject, gridObject.gridPosition + relativePos);
                }
            }
        }
        if (allowMove)
        {
            obj.Move(pos);
        }

        return allowMove;
    }
}
