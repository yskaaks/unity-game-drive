using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Buttons : MonoBehaviour
{

    public Sprite btnPressed, btnActive;
    private Transform child;
    private float cor_y;
    public static bool moveCar;


    void OnMouseDown()
    {
        if (gameObject.name == "Music" && PlayerPrefs.GetString("Music") == "no")
            child = transform.GetChild(1).transform;
        else
            child = transform.GetChild(0).transform;

        cor_y = child.localPosition.y;

        if (gameObject.name != "No ads")
        {
            GetComponent<Image>().sprite = btnPressed;
            child.localPosition = new Vector3(child.localPosition.x, 0, child.localPosition.z);
        } else if (PlayerPrefs.GetString("NoAds") != "yes")
        {
            GetComponent<Image>().sprite = btnPressed;
            child.localPosition = new Vector3(child.localPosition.x, 0, child.localPosition.z);
        }
    }
    void OnMouseUp()
    {

        if (gameObject.name == "Music" && PlayerPrefs.GetString("Music") == "no")
            child = transform.GetChild(1).transform;
        else
            child = transform.GetChild(0).transform;

        if (gameObject.name != "No ads")
        {
            GetComponent<Image>().sprite = btnActive;
            child.localPosition = new Vector3(child.localPosition.x, cor_y, child.localPosition.z);
        }
        else if (PlayerPrefs.GetString("NoAds") != "yes")
        {
            GetComponent<Image>().sprite = btnActive;
            child.localPosition = new Vector3(child.localPosition.x, cor_y, child.localPosition.z);
        }
    }

    void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Play":
                moveCar = true;
                StartCoroutine(loadScene("game"));
                break;
            case "Facebook":
                Application.OpenURL("https://www.facebook.com/profile.php?id=100007494526231");
                break;
            case "Shop":
                StartCoroutine(loadScene("shop"));
                break;
            case "Restart":
                StartCoroutine(loadScene("game"));
                break;
            case "Exit Shop":
                StartCoroutine(loadScene("main"));
                break;
        }
    }
    IEnumerator loadScene(string scene)
    {
        float fadeTime = Camera.main.GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(scene);
    }
}