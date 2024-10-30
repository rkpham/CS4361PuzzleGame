using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridObject : MonoBehaviour
{
    public Vector3Int gridPosition = Vector3Int.zero;
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
    public virtual void Step()
    {
        GridManager.instance.RequestMove(this, gridPosition + Vector3Int.down);
    }

    public virtual void Move(Vector3Int pos)
    {
        gridPosition = pos;
    }

    // Smoothly slides a GridObject to where it should be visually.
    protected void LerpToPosition()
    {
        transform.position = Vector3.Lerp(transform.position, gridPosition, 32.0f * Time.deltaTime);
    }
}
