using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    public void Resets()
    {
        PlayerPrefs.DeleteAll();
    }
}
