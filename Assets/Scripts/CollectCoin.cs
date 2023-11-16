using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCoin : MonoBehaviour {

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Car")
        {
            PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + 1);
            GameObject.Find ("Text Coin").GetComponent <Text> ().text = PlayerPrefs.GetInt("Coins").ToString ();

            Destroy(transform.parent.gameObject);
        }
    }

}
