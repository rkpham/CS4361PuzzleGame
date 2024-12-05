using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour
{
     void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Hazard")
        {
            LoadScene();
        }
    }
    void LoadScene()
    {
        
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevelIndex);
    }
}
