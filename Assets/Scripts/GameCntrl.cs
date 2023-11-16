using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCntrl : MonoBehaviour {
    public GameObject car, carParked, brakes;
    public Text score, bestScore, coins;
    public float stopObj = 8f;
    [HideInInspector]
    public static bool stop;
    private GameObject carInst;
    private int countCars = 0;
    private bool addStop;

    void Awake ()
    {
        stop = false;
        CheckClick.click = false;
        MoveObjects.speed = 20f;
    }

    void Start ()
    {
        Application.targetFrameRate = 60;
        carInst = Instantiate(car, new Vector3(-25f, -0.06f, -10f), Quaternion.Euler(new Vector3(0, -90, 0))) as GameObject;
    }

    void Update ()
    {
        if (MoveObjects.speed > 0 && stop)
        {
            MoveObjects.speed -= stopObj * Time.deltaTime;
            if (MoveObjects.speed < 0)
            {
                MoveObjects.speed = 0;
            }
        }
        if (stop && !PlayerLose.lose)
        {
            float rot = CreateBorder.side == "Left" ? 275 : -275;
            float z = CreateBorder.side == "Left" ? -15f : -5f;
            carInst.transform.position = Vector3.MoveTowards(carInst.transform.position, new Vector3 (carInst.transform.position.x, carInst.transform.position.y, z), 7 * Time.deltaTime); 
            carInst.transform.Rotate(Vector3.up * rot * Time.deltaTime);

            if (CreateBorder.side == "Left" && Mathf.Abs (carInst.transform.eulerAngles.y - 90) < 5f)
                StopRotate();
            if (CreateBorder.side == "Right" && carInst.transform.eulerAngles.y - 90 < 5f)
                StopRotate();
        }
        if (CheckClick.click && !addStop)
        {
            addStop = true;
            stop = true;
            Instantiate(brakes, new Vector3(carInst.transform.position.x, 0, carInst.transform.position.z), Quaternion.Euler(0, 0, 0));
        }
    }
    void StopRotate ()
    {
        float zPos = CreateBorder.side == "Left" ? -15f : -5f;
        StartCoroutine(NextCar(zPos));
        stop = false;
        CheckClick.click = false;
        MoveObjects.speed = 0;
        carInst.transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    void OnMouseDown ()
    {
        if (!PlayerLose.lose)
        {
            stop = true;
            MoveObjects.speed = 20;
        }
    }
    IEnumerator NextCar(float zPos)
    {
        while (carInst.transform.position.z != zPos)
        {
            carInst.transform.position = Vector3.MoveTowards(carInst.transform.position, new Vector3(carInst.transform.position.x, carInst.transform.position.y, zPos), 5 * Time.deltaTime);
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(1f);
        if (!PlayerLose.lose)
        {
            print("Next Car");
            addStop = false;
            carInst.AddComponent<MoveObjects>();
            if (PlayerPrefs.GetString ("Learn") != "yes")
            {
                PlayerPrefs.SetString("Learn", "yes");
            }

            countCars++;
            score.text = countCars.ToString ();
            if (PlayerPrefs.GetInt ("Score") < countCars)
            {
                PlayerPrefs.SetInt("Score", countCars);
                bestScore.text = "BEST: " + countCars.ToString();
            }
            if (countCars % 5 == 0)
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1);
                coins.text = PlayerPrefs.GetInt("Coins").ToString ();
            }

            carInst = Instantiate(car, new Vector3(-25f, -0.06f, -10f), Quaternion.Euler(new Vector3(0, -90, 0))) as GameObject;
            MoveObjects.speed = Random.Range(18f, 50f);
        }
    }

}
