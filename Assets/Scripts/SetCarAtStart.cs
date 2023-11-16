using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCarAtStart : MonoBehaviour {


    void Awake ()
    {
        if (PlayerPrefs.GetString ("Current Car") == "")
        {
            PlayerPrefs.SetString("Current Car", "Pizza Car");
            PlayerPrefs.SetString("Pizza Car", "Unlocked");
        }
    }
}
