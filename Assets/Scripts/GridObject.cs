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

    void Update()
    {
        LerpToPosition();
    }

    // Step is usually called when the Player does an input
    // Essentially, this is what you want to happen when a "turn" has passed
    public abstract void Step();

    public virtual void Move(Vector2Int pos)
    {
        gridPosition = pos;
    }

    // Smoothly slides a GridObject to where it should be visually.
    protected void LerpToPosition()
    {
        var horizPos = new Vector2(transform.position.x, transform.position.z);
        var nextHorizPos = Vector2.Lerp(horizPos, gridPosition, 16.0f * Time.deltaTime);
        transform.position = new Vector3(nextHorizPos.x, 0.0f, nextHorizPos.y);
    }
}
