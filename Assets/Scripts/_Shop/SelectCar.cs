using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCar : MonoBehaviour {
    public Sprite check;
    public Text carName;

    void OnMouseUp ()
    {
        PlayerPrefs.SetString("Current Car", carName.text);
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = check;
    }
}
