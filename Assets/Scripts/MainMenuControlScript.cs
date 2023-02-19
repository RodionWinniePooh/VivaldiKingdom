using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuControlScript : MonoBehaviour {

	public Button Button2Level, Button3Level, Button4Level, Button5Level;
	int levelPassed;
    public AudioSource audioSource;

	// Use this for initialization
	void Start () {
		levelPassed = PlayerPrefs.GetInt ("LevelPassed");
		Button2Level.interactable = false;
		Button3Level.interactable = false;
        Button4Level.interactable = false;
        Button5Level.interactable = false;

        if (levelPassed > 4)
        {
            levelPassed = 4;
        }

		switch (levelPassed) {
		    case 1:
		    	Button2Level.interactable = true;
		    	break;
		    case 2:
		    	Button2Level.interactable = true;
		    	Button3Level.interactable = true;
		    	break;
            case 3:
                Button2Level.interactable = true;
                Button3Level.interactable = true;
                Button4Level.interactable = true;
                break;
            case 4:
                Button2Level.interactable = true;
                Button3Level.interactable = true;
                Button4Level.interactable = true;
                Button5Level.interactable = true;
                break;

          
		}
	}
	
	public void levelToLoad (int level) //Загрузка сцены указывается в Unity на OnClick
	{
        audioSource.Play();
		SceneManager.LoadScene (level+1);
	}

	public void resetPlayerPrefs()
	{
		Button2Level.interactable = false;
		Button3Level.interactable = false;
        Button4Level.interactable = false;
        Button5Level.interactable = false;
		PlayerPrefs.DeleteAll ();
	}

    public void Menu()
    {
        audioSource.Play();
        SceneManager.LoadScene("Menu");
    }
}
