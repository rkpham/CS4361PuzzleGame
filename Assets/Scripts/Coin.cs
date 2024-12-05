using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    private AudioSource audioSource;
    //collided with a coin
    void Start()
    {
        // Get the AudioSource component attached to the coin
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("No AudioSource component found on the coin game object.");
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            ScoreManager.Instance.addScore(5);
            EventManager.RaiseOnCoinPickedUp();
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }
            Destroy(gameObject,audioSource.clip.length);
            ScoreManager.Instance.addScore(5); //add 5 points for coin
        }
    }
    void FixedUpdate()
    {
        transform.Rotate(0, Time.fixedDeltaTime * 120f, 0);
    }
}
