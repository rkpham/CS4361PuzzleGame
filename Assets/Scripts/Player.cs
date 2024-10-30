using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GridObject
{

    // Update is called once per frame
    void Update()
    {
        bool moved = false;
        LerpToPosition();
        if (Input.GetKeyDown(KeyCode.D))
        {
            moved = GridManager.instance.RequestMove(this, gridPosition + Vector3Int.right);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            moved = GridManager.instance.RequestMove(this, gridPosition + Vector3Int.left);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            moved = GridManager.instance.RequestMove(this, gridPosition + Vector3Int.forward);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            moved = GridManager.instance.RequestMove(this, gridPosition + Vector3Int.back);
        }
        // Spacebar to wait a step
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GridManager.instance.Step();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // Reset level
        }

        if (moved)
        {
            GridManager.instance.Step();
        }
    }
    private void FixedUpdate()
    {
        
    }
}
