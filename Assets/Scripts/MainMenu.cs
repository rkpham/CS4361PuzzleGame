using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlayPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnControlsPressed()
    {
        Debug.Log("button pressed.");
    }

    public void OnQuitPressed()
    {
        Application.Quit();
    }
}
