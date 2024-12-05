using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    //collided with a coin
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            ScoreManager.Instance.addScore(5);
            EventManager.RaiseOnCoinPickedUp();
            Destroy(gameObject);
            ScoreManager.Instance.addScore(5); //add 5 points for coin
        }
    }
    void FixedUpdate()
    {
        transform.Rotate(0, Time.fixedDeltaTime * 120f, 0);
    }
}
