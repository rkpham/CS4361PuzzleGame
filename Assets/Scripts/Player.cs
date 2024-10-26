using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GridObject
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            GridManager.instance.RequestMove(this, gridPosition + Vector2Int.right);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            GridManager.instance.RequestMove(this, gridPosition + Vector2Int.left);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            GridManager.instance.RequestMove(this, gridPosition + Vector2Int.up);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            GridManager.instance.RequestMove(this, gridPosition + Vector2Int.down);
        }
    }
    private void FixedUpdate()
    {
        var horizPos = new Vector2(transform.position.x, transform.position.z);
        var nextHorizPos = Vector2.Lerp(horizPos, gridPosition, 0.9f);
        transform.position = new Vector3(nextHorizPos.x, 0.0f, nextHorizPos.y);
    }

    override public void Step()
    {

    }

    override public void Move(Vector2Int pos)
    {
        gridPosition = pos;
    }
}
