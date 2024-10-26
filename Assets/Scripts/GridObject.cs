using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridObject : MonoBehaviour
{
    public Vector2Int gridPosition = Vector2Int.zero;
    void Start()
    {
        gridPosition = GridManager.WorldToGrid(transform.position);
    }

    void Update() {}

    void FixedUpdate()
    {
        
    }

    // Step is usually called when the Player does an input.
    public abstract void Step();

    public virtual void Move(Vector2Int pos)
    {
        gridPosition = pos;
    }
}
