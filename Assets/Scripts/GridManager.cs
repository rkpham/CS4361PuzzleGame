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
    static Vector2 gridSize = new Vector2(1, 1);

    public List<GridObject> gridObjects = new List<GridObject>();

    private void Start()
    {
        foreach (GridObject obj in Resources.FindObjectsOfTypeAll(typeof(GridObject)))
        {
            gridObjects.Add(obj);
        }
    }

    // Converts an world position to a grid position (these are Vector2s!)
    public static Vector2Int WorldToGrid(Vector2 worldPosition)
    {
        return Vector2Int.RoundToInt(worldPosition / gridSize);
    }

    // Converts a grid position to a world position
    public static Vector2 GridToWorld(Vector2Int gridPosition)
    {
        return gridPosition * gridSize;
    }

    // Handles requests by GridObjects to move to a certain arbitrary global grid position.
    public bool RequestMove(GridObject obj, Vector2Int pos)
    {
        if (gridObjects.Count == 0)
        {
            obj.Move(pos);
            return true;
        }

        Vector2Int relativePos = pos - obj.gridPosition;
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
