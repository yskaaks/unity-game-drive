using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NowCar : MonoBehaviour {

    public Sprite thisOne, selectCar;
    public Text carName;
    public GameObject openCar, buyCar;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car")
        {
            other.transform.localScale += new Vector3 (0.2f, 0.2f, 0.2f);

            carName.text = other.name;
            if (PlayerPrefs.GetString (other.name) == "Unlocked")
            {
                openCar.SetActive (true);
                buyCar.SetActive(false);
                if (PlayerPrefs.GetString("Current Car") == other.name )
                {
                    openCar.transform.GetChild (0).GetComponent <Image>().sprite = thisOne;
                }
                else
                {
                    openCar.transform.GetChild(0).GetComponent<Image>().sprite = selectCar;
                }

            }
            else
            {
                buyCar.SetActive(true);
                openCar.SetActive(false);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Car")
            other.transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
    }
}
