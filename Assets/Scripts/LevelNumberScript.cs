using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelNumberScript : MonoBehaviour {

	Text text;
	int sceneIndex;

	void Start () {
		text = GetComponent<Text> ();
		sceneIndex = SceneManager.GetActiveScene ().buildIndex-1;
	}
	
	void Update () {
        if (sceneIndex == 6)
        {
            text.text = "Training camp";
        }
        if (sceneIndex == 5)
        {
            text.text = "Ice Golem";
        }
        else
		text.text = "Level " + sceneIndex;
	}
}
