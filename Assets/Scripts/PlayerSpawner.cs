using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Player player;

    private IEnumerator spawncoroutine;

    private void OnEnable()
    {
        EventManager.onPlayerDied += PlayerDied;
    }

    private void PlayerDied()
    {
        spawncoroutine = SpawnPlayer();
        StartCoroutine(spawncoroutine);
    }

    IEnumerator SpawnPlayer()
    {
        yield return new WaitForSeconds(2);
        player.transform.position = transform.position + new Vector3(0, 1, 0);
        player.Revive();
    }

    private void OnDestroy()
    {
        EventManager.onPlayerDied -= PlayerDied;
    }
}
