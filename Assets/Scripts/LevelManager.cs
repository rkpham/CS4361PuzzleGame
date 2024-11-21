using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static EventManager;

public class LevelManager : MonoBehaviour
{
    static public int CurrentLevel = 0;
    static public int CoinsPickedUp = 0;
    private void OnEnable()
    {
        EventManager.onCoinPickedUp += CoinPickedUp;
    }
    private void CoinPickedUp()
    {
        CoinsPickedUp += 1;
    }
    static public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.SetActiveScene(SceneManager.GetActiveScene());
    }

    private void OnDestroy()
    {
        EventManager.onCoinPickedUp -= CoinPickedUp;
    }
}
