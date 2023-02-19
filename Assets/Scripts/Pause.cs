using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public AudioSource audioSource;

    public GameObject PauseMenu;

    public void pauseGame()
    {
        Time.timeScale = 0; //Время стоп
        PauseMenu.SetActive(true);
    }


    public void Resume()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);

    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelect");
    }

    public void Quit()
    {
        Application.Quit();
    }
}


