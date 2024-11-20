using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class LevelManager : MonoBehaviour
{
    static public int CoinsPickedUp = 0;
    static public int NumButtonsActivated = 0;
    private void OnEnable()
    {
        EventManager.onCoinPickedUp += CoinPickedUp;
        EventManager.onButtonActivated += ButtonActivated;
        EventManager.onButtonDeactivated += ButtonDeactivated;
    }
    private void CoinPickedUp()
    {
        CoinsPickedUp += 1;
    }
    private void ButtonActivated()
    {
        NumButtonsActivated += 1;
    }
    private void ButtonDeactivated()
    {
        NumButtonsActivated -= 1;
    }
}
