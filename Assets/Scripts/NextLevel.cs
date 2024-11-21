using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Finish")
        {
            LoadNext();
        }
    }

    void LoadScene()
    {
        
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevelIndex);
    }

    void LoadNext()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentLevel + 1;
        if(nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
            
        }
        SceneManager.LoadScene(nextScene);
       
    }
}
