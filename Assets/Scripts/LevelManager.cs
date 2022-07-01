using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestartLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex; // þuanki sahnemizi referans alan kod satýrý
        SceneManager.LoadScene(currentScene);
    }
    public void NextLevel()  // eðer bir sonraki levele geçersek ;
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;  // bu satýrda bir deðiþken oluþturdum , oluþturduðum deðiþkeni de bir sonraki leveli referans alan kod a aktardým.
        int sceneIndex = SceneManager.sceneCountInBuildSettings - 1;     // bu satýrda bir deðiþken oluþturdum , oluþturduðum deðiþkeni de bir önceki leveli referans alan kod a aktardým
        if (nextSceneIndex <= sceneIndex)   
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        if (nextSceneIndex > sceneIndex)
        {
            SceneManager.LoadScene(0);
        }
    }
}
