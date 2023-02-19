using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public string nameScene;
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelect");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ResetLevel()
    {
        Time.timeScale = 1; // Время идет
        SceneManager.LoadScene(nameScene);
    }
}
