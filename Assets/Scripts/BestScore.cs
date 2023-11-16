using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    void Start ()
    {
        GetComponent<Text>().text = "BEST: " + PlayerPrefs.GetInt("Score").ToString();
    }

}
