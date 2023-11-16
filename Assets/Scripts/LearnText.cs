using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LearnText : MonoBehaviour {



	void Update () {
        GetComponent<Text>().color = Color.Lerp (GetComponent <Text> ().color, Color.white, 0.8f * Time.deltaTime);
        if (PlayerLose.lose || PlayerPrefs.GetString("Learn") == "yes")
        {
            gameObject.SetActive(false);
        }
	
        	
	}
}
