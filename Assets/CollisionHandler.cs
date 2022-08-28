using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class CollisionHandler : MonoBehaviour
{
   
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Fuel":
                Debug.Log("Fuel");
                break;
            case "Friendly":
                Debug.Log("Friendly");
                break ;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                CrashStartSequence();
                break;
     
        }
    }

    void StartSuccessSequence()
    {
        GetComponent<Mover>().enabled = false ;
        Invoke("NextLevel", 1f);
    }

    void CrashStartSequence()
    {
        GetComponent<Mover>().enabled = false;
        Invoke("ReloadLevel", 1f);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void NextLevel()
    {
        
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevelIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextLevelIndex = 0;
        }
            SceneManager.LoadScene(nextLevelIndex);
    }

}
