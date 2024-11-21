using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private float color = 0.0f;

    [SerializeField] private Image BackgroundImage;

    private void FixedUpdate()
    {
        BackgroundImage.color = Color.HSVToRGB(color, 0.4f, 0.6f);
        color += Time.fixedDeltaTime * 0.1f;
        if (color > 1.0f)
            color = 0.0f;
    }

    public void OnPlayPressed()
    {
        LevelManager.LoadNextLevel();
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
