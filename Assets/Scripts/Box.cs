using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : GridObject
{
    private void FixedUpdate()
    {
        var horizPos = new Vector2(transform.position.x, transform.position.z);
        var nextHorizPos = Vector2.Lerp(horizPos, gridPosition, 0.9f);
        transform.position = new Vector3(nextHorizPos.x, 0.0f, nextHorizPos.y);
    }

    override public void Step()
    {

    }
}
