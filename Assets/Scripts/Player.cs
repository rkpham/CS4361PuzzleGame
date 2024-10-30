using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GridObject
{

    // Update is called once per frame
    void Update()
    {
        LerpToPosition();
        if (Input.GetKeyDown(KeyCode.D))
        {
            GridManager.instance.RequestMove(this, gridPosition + Vector3Int.right);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            GridManager.instance.RequestMove(this, gridPosition + Vector3Int.left);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            GridManager.instance.RequestMove(this, gridPosition + Vector3Int.forward);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            GridManager.instance.RequestMove(this, gridPosition + Vector3Int.back);
        }
    }
    private void FixedUpdate()
    {
        
    }

    override public void Step()
    {

    }
}
