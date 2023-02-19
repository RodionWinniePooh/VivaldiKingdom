using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControlScript : MonoBehaviour {

    Text textLoseScoreCoins;
    Text textWiScoreCoins;

    public static LevelControlScript instance = null;
    public GameObject scoreCoinsLose;
    public GameObject scoreCoinsWin;

    public static GameObject levelSign;
	public static int sceneIndex, levelPassed;

    public GameObject LoseMenu;
    public GameObject WinMenu;

	// Use this for initialization
	void Start () {

        Goblin.isAttacking = false;
        Application.targetFrameRate = 61;

        if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		levelSign = GameObject.Find ("LevelNumber");
		sceneIndex = SceneManager.GetActiveScene().buildIndex;
		levelPassed = PlayerPrefs.GetInt ("LevelPassed");
        PlayerPrefs.Save();
        textLoseScoreCoins = scoreCoinsLose.gameObject.GetComponent<Text>();
        textWiScoreCoins = scoreCoinsWin.gameObject.GetComponent<Text>();
    }

	public void youWin()
	{
        levelSign.gameObject.SetActive(false);
        textWiScoreCoins.text = "Coins: " + Hero.scoreCoinsLevel.ToString();

        if (LevelControlScript.levelPassed < LevelControlScript.sceneIndex)
            PlayerPrefs.SetInt("LevelPassed", LevelControlScript.sceneIndex - 1);

        Invoke("Win", 1f);
    }

	public void youLose()
	{
		levelSign.gameObject.SetActive (false);
        textLoseScoreCoins.text = "Coins: " + Hero.scoreCoinsLevel.ToString();
        Invoke("Lose", 1f);

	}

	void loadNextLevel()
	{
		SceneManager.LoadScene (sceneIndex+1);
	}

	void loadMainMenu()
	{
		SceneManager.LoadScene ("LevelSelect");
	}

    void Lose()
    {
        Time.timeScale = 0;
        Goblin.isAttacking = false;
        LoseMenu.SetActive(true);
    }

    void Win()
    {
        Time.timeScale = 0;
        Goblin.isAttacking = false;
        WinMenu.SetActive(true);
    }
}
