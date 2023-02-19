using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    MainMenuControlScript main;
    public AudioSource audioSource;
    int level;
    
    public MenuControls(MainMenuControlScript main)
    {
        
        this.main = main;
    }

    public void PlayPressed()
    {
        audioSource.Play();
        SceneManager.LoadScene("LevelSelect");
    }

    public void TrainingScene()
    {
        audioSource.Play();
        SceneManager.LoadScene("Training");
    }

    public void resetPlayerPrefs()
    {

        //main.Button2Level.interactable = false;
        //main.Button3Level.interactable = false;
        //main.Button4Level.interactable = false;
        //main.Button5Level.interactable = false;
        audioSource.Play();
        PlayerPrefs.DeleteAll();
        
    }

    public void Shop()
    {
        audioSource.Play();
        SceneManager.LoadScene("Shop");
    }

    public void ExitPressed()
    {
        audioSource.Play();
        Application.Quit();
        //Debug.Log("Exit pressed!");
    }

    private void Start()
    {
        level = PlayerPrefs.GetInt("LevelPassed");
        Debug.Log(level);
        Application.targetFrameRate = 61;
    }

}
