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
        int currentScene = SceneManager.GetActiveScene().buildIndex; // �uanki sahnemizi referans alan kod sat�r�
        SceneManager.LoadScene(currentScene);
    }
    public void NextLevel()  // e�er bir sonraki levele ge�ersek ;
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;  // bu sat�rda bir de�i�ken olu�turdum , olu�turdu�um de�i�keni de bir sonraki leveli referans alan kod a aktard�m.
        int sceneIndex = SceneManager.sceneCountInBuildSettings - 1;     // bu sat�rda bir de�i�ken olu�turdum , olu�turdu�um de�i�keni de bir �nceki leveli referans alan kod a aktard�m
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
