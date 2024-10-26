using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepManager : MonoBehaviour
{
    List<GridObject> gridObjects = new List<GridObject>();

    void Step()
    {
        for (int i = 0; i < gridObjects.Count; i++)
        {
            gridObjects[i].Step();
        }
    }
}
