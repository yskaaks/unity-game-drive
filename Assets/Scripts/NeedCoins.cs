using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedCoins : MonoBehaviour {

    public Text needMore;

    void Start ()
    {
        if (PlayerPrefs.GetInt ("Coins") >= 100)
        {
            transform.GetChild(0).gameObject.SetActive (false);
            transform.GetChild(1).gameObject.SetActive (true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);


            // set new text
            needMore.text = "You need " + (100 - PlayerPrefs.GetInt ("Coins")).ToString () + " more";

        }
    }


}
