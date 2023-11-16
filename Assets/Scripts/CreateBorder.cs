using UnityEngine;
using System.Collections;

public class CreateBorder : MonoBehaviour {

    public static string side; 
    public GameObject borders, blinking, learn, coin;
    private GameObject borderRight, borderLeft;
    private int randSpaces, randSide, randCoin;
    void Start()
    {
        randSpaces = Random.Range(15, 25);
        randSide = Random.Range(1, 3);
        randCoin = Random.Range(3, 7);

        if (PlayerPrefs.GetString("Learn") != "yes")
        {
            randSpaces = 5;
            learn.SetActive (true);
        }

        for (int i = 0; i < 14; i++)
        {
            float xPos = borderRight == null ? -10f : borderRight.GetComponent<MeshRenderer>().bounds.size.x + Random.Range(3f, 5f) + borderRight.transform.position.x;
            borderRight = Instantiate(borders, new Vector3(xPos, 0f, -4.1f), Quaternion.identity) as GameObject;

            float yPos = borderLeft == null ? -10f : borderLeft.GetComponent<MeshRenderer>().bounds.size.x + Random.Range(3f, 5f) + borderLeft.transform.position.x;
            borderLeft = Instantiate(borders, new Vector3(yPos, 0f, -15.8f), Quaternion.identity) as GameObject;
        }
    }
    void Update()
    {

        if (borderRight.transform.position.x < 30f)
        {
            randSpaces--;
            float rand = randSpaces <= 0 && randSide == 1 ? Random.Range(10f, 15f) : Random.Range(1f, 3f);
            if (randSpaces <= 0 && randSide == 1)
            {
                RandomNums(rand, -3.12f, borderRight);
                side = "Right";
            }
            borderRight = Instantiate(borders, new Vector3(borderRight.GetComponent<MeshRenderer> ().bounds.size.x + rand + borderRight.transform.position.x, 0f, -4.1f), Quaternion.identity) as GameObject;            
        }
        if (borderLeft.transform.position.x < 30f)
        {
            float rand = randSpaces <= 0 && randSide == 2 ? Random.Range(10f, 15f) : Random.Range(1f, 3f);
            if (randSpaces <= 0 && randSide == 2)
            {
                RandomNums(rand, -16.9f, borderLeft);
                side = "Left";
            }
            borderLeft = Instantiate(borders, new Vector3(borderLeft.GetComponent<MeshRenderer> ().bounds.size.x + rand + borderLeft.transform.position.x, 0f, -15.8f), Quaternion.identity) as GameObject;
            }
        }
    void RandomNums(float rand, float zPos, GameObject border)
    {
        randSpaces = Random.Range(15, 25);
        randSide = Random.Range(1, 3);

        if (rand > 5f)
        {
            randCoin--;
            GameObject blink = Instantiate(blinking, new Vector3(1f + border.transform.position.x + rand / 2, 0.5f, zPos), Quaternion.identity) as GameObject;
            blink.transform.localScale = new Vector3(rand, 0.03f, 0.3f);
            if (randCoin == 0)
            {
                float z = zPos == -16.9f ? -15.5f : -4.39f;
                Instantiate(coin, new Vector3(1f + border.transform.position.x + rand / 2, 1f, z), Quaternion.Euler (41,90,0));
                randCoin = Random.Range(3, 7);
            }
        }
    }
} 
