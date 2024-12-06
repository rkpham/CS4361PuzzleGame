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
            EventManager.RaiseOnCoinPickedUp();
<<<<<<< Updated upstream
            Destroy(gameObject);
=======
            Destroy(gameObject, audioSource.clip.length);
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }
>>>>>>> Stashed changes
            ScoreManager.Instance.addScore(5); //add 5 points for coin
        }
    }
    void FixedUpdate()
    {
        transform.Rotate(0, Time.fixedDeltaTime * 120f, 0);
    }
}
