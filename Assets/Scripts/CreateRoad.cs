using UnityEngine;
using System.Collections;

public class CreateRoad : MonoBehaviour
{

    public GameObject[] roadInst;
    private GameObject currentRoad;
    private int nextLocation;

    void Start ()
    {
        nextLocation = Random.Range (3,5);
        currentRoad = Instantiate (roadInst[Random.Range(0, roadInst.Length)], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
    }

    void FixedUpdate ()
    {
        if (currentRoad.transform.position.x < 0)
        {
            currentRoad = Instantiate(roadInst[Random.Range(0, roadInst.Length)], new Vector3(currentRoad.transform.position.x + 53.1f, 0, 0), Quaternion.identity) as GameObject;
            nextLocation--;
        }
    }

}
