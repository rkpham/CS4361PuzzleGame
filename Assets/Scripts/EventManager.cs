using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnPlayerDied();
    public static event OnPlayerDied onPlayerDied;

    public delegate void OnButtonActivated();
    public static event OnButtonActivated onButtonActivated;
    
    public delegate void OnButtonDeactivated();
    public static event OnButtonDeactivated onButtonDeactivated;

    public delegate void OnCoinPickedUp();
    public static event OnCoinPickedUp onCoinPickedUp;
    public static void RaiseOnPlayerDied()
    {
        if (onPlayerDied != null)
        {
            onPlayerDied();
        }
    }

    public static void RaiseOnCoinPickedUp()
    {
        if (onCoinPickedUp != null)
        {
            onCoinPickedUp();
        }
    }

    public static void RaiseOnButtonActivated()
    {
        if (onButtonActivated != null)
        {
            onButtonActivated();
        }
    }

    public static void RaiseOnButtonDeactivated()
    {
        if (onButtonActivated != null)
        {
            onButtonActivated();
        }
    }
}
