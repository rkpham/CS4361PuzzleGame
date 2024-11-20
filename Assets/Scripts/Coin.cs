using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "Player")
        {
            EventManager.RaiseOnCoinPickedUp();
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        transform.Rotate(0, Time.fixedDeltaTime * 120f, 0);
    }
}
