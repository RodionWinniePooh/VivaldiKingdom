using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void MainMenu()
    {
        Debug.Log(LevelControlScript.sceneIndex == 6);
        if (LevelControlScript.sceneIndex == 6)
        {
            SceneManager.LoadScene("LevelSelect");
            Time.timeScale = 1;
            if (LevelControlScript.levelPassed < LevelControlScript.sceneIndex)
                PlayerPrefs.SetInt("LevelPassed", LevelControlScript.sceneIndex - 1);
        }
        else
        {
            if (LevelControlScript.levelPassed < LevelControlScript.sceneIndex)
                PlayerPrefs.SetInt("LevelPassed", LevelControlScript.sceneIndex - 1);
            LevelControlScript.levelSign.gameObject.SetActive(false);
            SceneManager.LoadScene(LevelControlScript.sceneIndex + 1);
            Invoke("loadNextLevel", 1f);
        }
    }

    void loadMainMenu()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    void loadNextLevel()
    {
        SceneManager.LoadScene(LevelControlScript.sceneIndex + 1);
    }
}
