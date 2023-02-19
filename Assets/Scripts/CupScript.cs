using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
        if (LevelControlScript.sceneIndex == 6 && Hero.daggerInt == 1 )
        {
            LevelControlScript.instance.youWin();
        }
        if (LevelControlScript.sceneIndex != 6)
        {
            LevelControlScript.instance.youWin();
        }
	}
}
